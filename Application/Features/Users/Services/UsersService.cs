using Application.Base.Services;
using Application.Features.Auth.Services;
using Application.Features.Files.Services;
using Application.Features.Users.Models;
using Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Services;

public class UsersService(UserIdentity userIdentity, RDbContext db, FilesService filesService) : BaseDbService(db)
{
    private readonly UserIdentity _userIdentity = userIdentity;
    private readonly FilesService _filesService = filesService;

	public async Task<RUser> CreateUser(RUser user)
    {
        MasterDbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;

		await MasterDbContext.AddAsync(user);
        await MasterDbContext.SaveChangesAsync();

		return user;
    }

    public async Task<RUser?> GetUser(Guid userId) => await MasterDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

	public async Task<RUser?> GetUserByEmail(string email) => await MasterDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<RUser> GetUser() => await MasterDbContext.Users
	    .Include(q => q.Image)
	    .FirstAsync(q => q.Id == _userIdentity.UserId);

    public async Task<RUser> UpdateProfile(UpdateUserProfileModel model)
    {
	    var user = await GetUser();

	    user.Email = model.Email ?? user.Email;
	    user.Password = model.Password ?? user.Password;
	    user.Name = model.Name ?? user.Name;
	    
	    if (model.Image != null)
	    {
		    if (user.Image == null)
		    {
			    user.Image = new RImage
			    {
				    Name = await _filesService.Write(model!.Image)
			    };
		    }
		    else
		    {
			    user.Image.Name = await _filesService.Write(model!.Image);
		    }
		  
		    
	    }

	    MasterDbContext.Update(user);
	    await MasterDbContext.SaveChangesAsync();
	    
	    return user;
    }
}
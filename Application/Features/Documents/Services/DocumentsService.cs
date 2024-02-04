using Application.Base.Extensions;
using Application.Base.Interfaces;
using Application.Base.Services;
using Application.Features.Documents.Model;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Documents.Services;

public class DocumentsService(UWDbContext dbContext, IMapper mapper) : BaseDbService(dbContext)
{
	private readonly IMapper _mapper = mapper;

	public async Task<ICollection<DocumentModel>> GetDocuments(ICollectionFilter? filter)
	{
		var bills = MasterDbContext.Bills.ProjectTo<DocumentModel>(_mapper.ConfigurationProvider);

		return await bills.ApplyCollectionFilter(filter).ToListAsync();
	} 
}

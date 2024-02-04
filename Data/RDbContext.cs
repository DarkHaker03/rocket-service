using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class RDbContext(DbContextOptions<RDbContext> options) : DbContext(options)
{

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RUser).Assembly);
		base.OnModelCreating(modelBuilder);
	}

	public DbSet<RUser> Users { get; set; }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data;

public class UWDbContext(DbContextOptions<UWDbContext> options) : DbContext(options)
{

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UwUser).Assembly);
		base.OnModelCreating(modelBuilder);
		
        modelBuilder.HasSequence<long>("BillNumbers");
        
		modelBuilder.Entity<UwBill>()
			.Property(b => b.Number)
			.HasDefaultValueSql("nextval('\"BillNumbers\"')");
	}

	public DbSet<UwUser> Users { get; set; }

    public DbSet<UwProduct> Products { get; set; }
    public DbSet<UwImage> Images { get; set; }
    public DbSet<UwImageProductLink> ImageProductLinks { get; set; }
    
    public DbSet<UwBill> Bills { get; set; }

    public DbSet<UwWarehouse> Warehouses { get; set; }

    public DbSet<UwActionType> ActionTypes { get; set; }

    public DbSet<UwBasket> Baskets { get; set; }

    public DbSet<UwBasketReceivedProductLink> BasketReceivedProductLinks { get; set; }

    public DbSet<UwCar> Cars { get; set; }

    public DbSet<UwEmployee> Employees { get; set; }

    public DbSet<UwEmployeeType> EmployeeTypes { get; set; }

    public DbSet<UwReceivedProduct> ReceivedProducts { get; set; }

    public DbSet<UwProductCellAction> ReceivedProductActions { get; set; }

    public DbSet<UwReceivedProductCell> ReceivedProductCells { get; set; }
    
    public DbSet<UwProductStage> ProductStages { get; set; }
    public DbSet<UwCell> Cells { get; set; }
    
    public DbSet<UwProductBill> ProductBills { get; set; }

}

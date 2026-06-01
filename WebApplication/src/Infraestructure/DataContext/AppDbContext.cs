using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<DataBasic> DataBasics { get; set; }
    public DbSet<DataAddress> DataAddresses { get; set; }
    public DbSet<DataFinancial> DataFinancials { get; set; }
    public DbSet<DataSecurity> DataSecurities { get; set; }
}
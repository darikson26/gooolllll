
using Microsoft.EntityFrameworkCore;
using pc22222u202422620.Clinical.domain.Aggregates;

namespace pc22222u202422620.Clinical.Infrastructure.Persistence;

public class RoDbContext : DbContext
{
    public RoDbContext(DbContextOptions<RoDbContext> options) : base(options)
    {
        
    }
    public DbSet<Prescription>  Prescriptions => Set<Prescription>();
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PrescriptionConfiguration());
    }
    
}

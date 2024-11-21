using Microsoft.EntityFrameworkCore;
using TechnicalInterviewDayforce.Models;

namespace TechnicalInterviewDayforce.Configs;

public class PayrollDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public PayrollDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<TimecardRecord> Timecards { get; set; }
    public DbSet<RateTableRow> RateTable { get; set; }
    public DbSet<PaySummaryRecord> PaySummaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TimecardRecord>()
            .HasKey(t => new { t.EmployeeNumber, t.DateWorked });

        modelBuilder.Entity<RateTableRow>()
            .HasKey(r => new { r.Job, r.Dept, r.EffectiveStart });

        modelBuilder.Entity<PaySummaryRecord>()
            .HasKey(p => new { p.EmployeeNumber, p.Job, p.Dept });
    }
}
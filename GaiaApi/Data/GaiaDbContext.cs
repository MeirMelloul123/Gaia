using GaiaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GaiaApi.Data
{
    public class GaiaDbContext : DbContext
    {
        public GaiaDbContext(DbContextOptions<GaiaDbContext> options) : base(options)
        {
        }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationHistory> OperationHistory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>().ToTable("OPERATION");
            modelBuilder.Entity<Operation>().Property(o => o.Id).HasColumnName("ID");
            modelBuilder.Entity<Operation>().Property(o => o.Type).HasColumnName("TYPE").IsRequired();
            modelBuilder.Entity<Operation>().Property(o => o.Name).HasColumnName("NAME").IsRequired();
            modelBuilder.Entity<Operation>().Property(o => o.Formula).HasColumnName("FORMULA").IsRequired();
            modelBuilder.Entity<OperationHistory>().ToTable("OPERATION_HISTORY");
            modelBuilder.Entity<OperationHistory>().Property(o => o.Id).HasColumnName("ID");
            modelBuilder.Entity<OperationHistory>().Property(o => o.FirstField).HasColumnName("FIRST_FIELD");
            modelBuilder.Entity<OperationHistory>().Property(o => o.OperationId).HasColumnName("OPERATION_ID");
            modelBuilder.Entity<OperationHistory>().Property(o => o.SecondField).HasColumnName("SECOND_FIELD");
            modelBuilder.Entity<OperationHistory>().Property(o => o.Result).HasColumnName("RESULT");
            modelBuilder.Entity<OperationHistory>().Property(o => o.CreateAt).HasColumnName("CREATE_AT");
            // Composite index to speed queries filtering by OperationId and date range (e.g. monthly counts)
            modelBuilder.Entity<OperationHistory>()
                .HasIndex(h => new { h.OperationId, h.CreateAt })
                .HasDatabaseName("IX_OPERATION_HISTORY_OPERATION_ID_CREATE_AT");
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace EFCoreCRUD.Models
{
    public class CompanyContext : DbContext
    {

        public CompanyContext(DbContextOptions<CompanyContext> options): base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(d => d.Department)
                .WithMany(propa => propa.Employees)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Employees_Departments_DepartmentId");
            });
        }


    }
}

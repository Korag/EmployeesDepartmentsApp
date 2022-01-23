using EmployeesDepartments.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeesDepartments.DataAccess
{
    public class EFDbContext : DbContext
    {
        #region DbSets

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<DepartmentEmployeeModel> DepartmentEmployees { get; set; }

        #endregion

        private IConfiguration _config { get; set; }

        public EFDbContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuild)
        {
            optionsBuild.UseSqlServer(_config.GetConnectionString("Default"));

            base.OnConfiguring(optionsBuild);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentEmployeeModel>()
                        .HasKey(de => new { de.DepartmentId, de.EmployeeId });

            modelBuilder.Entity<DepartmentEmployeeModel>()
                        .HasOne(de => de.Department)
                        .WithMany(e => e.DepartmentEmployees)
                        .HasForeignKey(de => de.DepartmentId);

            modelBuilder.Entity<DepartmentEmployeeModel>()
                        .HasOne(de => de.Employee)
                        .WithMany(e => e.DepartmentEmployees)
                        .HasForeignKey(de => de.EmployeeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

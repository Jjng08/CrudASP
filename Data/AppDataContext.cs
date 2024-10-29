using Microsoft.EntityFrameworkCore;
using CrudASP.Models;

namespace CrudASP.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }

        public DbSet<Empleado> Empleados { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(tb => {
                tb.HasKey(col => col.IdEmpleado);
                tb.Property(col => col.IdEmpleado).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.Nombre).HasMaxLength(50);
                tb.Property(col => col.Email).HasMaxLength(50);
            });

            modelBuilder.Entity<Empleado>().ToTable("Empleados");
        }
    }
    

    
}

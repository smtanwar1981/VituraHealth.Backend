using Microsoft.EntityFrameworkCore;
using VituraHealth.Domain.Entities;

namespace VituraHealth.Infrastructure.Data
{
    public class VituraHealthDbContext : DbContext
    {
        public VituraHealthDbContext(DbContextOptions<VituraHealthDbContext> options) : base(options)
        {
        }

        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasKey(pres => pres.Id);
                entity.Property(pres => pres.Id).IsRequired();
                entity.Property(pres => pres.DrugName).IsRequired().HasMaxLength(200);
                entity.Property(pres => pres.Dosage).IsRequired();
                entity.Property(pres => pres.DatePrescribed).IsRequired();
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(pat => pat.Id);
                entity.Property(pat => pat.FullName).IsRequired().HasMaxLength(200);
                entity.Property(pat => pat.DateOfBirth).IsRequired();
            });            
            
            base.OnModelCreating(modelBuilder);
        }
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class VeterinaryOfficeContext : DbContext
    {
        public VeterinaryOfficeContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Visit> Visits { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Animal

            modelBuilder.Entity<Animal>().ToTable("Animals");
            modelBuilder.Entity<Animal>().HasKey(x => x.Id);
            modelBuilder.Entity<Animal>()
                .HasOne(x => x.Owner)
                .WithMany(y => y.Animals)
                .HasForeignKey(o => o.OwnerId);          
            modelBuilder.Entity<Animal>()
                .Property(x => x.Age)
                .IsRequired();
            modelBuilder.Entity<Animal>()
                .Property(x => x.AnimalType)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Animal>()
               .Property(x => x.Breed)
               .HasMaxLength(50)
               .IsRequired();
            modelBuilder.Entity<Animal>()
               .Property(x => x.Gender)
               .HasMaxLength(30)
               .IsRequired();
            modelBuilder.Entity<Animal>()
               .Property(x => x.Name)
               .HasMaxLength(50)
               .IsRequired();
            modelBuilder.Entity<Animal>()
               .Property(x => x.Weight)
               .HasMaxLength(10)
               .IsRequired();

            #endregion

            #region Medicine

            modelBuilder.Entity<Medicine>().ToTable("Medicines");
            modelBuilder.Entity<Medicine>().HasKey(x => x.Id);
            modelBuilder.Entity<Medicine>()
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            #endregion

            #region Owner

            modelBuilder.Entity<Owner>().ToTable("Owners");
            modelBuilder.Entity<Owner>().HasKey(x => x.Id);
            modelBuilder.Entity<Owner>()
                .Property(x => x.City)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Owner>()
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Owner>()
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Owner>()
                .Property(x => x.PostCode)
                .HasMaxLength(6)
                .IsRequired();
            modelBuilder.Entity<Owner>()
                .Property(x => x.Street)
                .HasMaxLength(50)
                .IsRequired();

            #endregion

            #region Vet

            modelBuilder.Entity<Vet>().ToTable("Vets");
            modelBuilder.Entity<Vet>().HasKey(x => x.Id);
            modelBuilder.Entity<Vet>()
                .Property(x => x.FirstName)
                .HasMaxLength(30)
                .IsRequired();
            modelBuilder.Entity<Vet>()
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            #endregion

            #region Visit

            modelBuilder.Entity<Visit>().ToTable("Visits");
            modelBuilder.Entity<Visit>().HasKey(x => x.Id);
            modelBuilder.Entity<Visit>()
                .HasOne(x => x.Animal)
                .WithMany(y => y.Visits)
                .HasForeignKey(a => a.AnimalId);
            modelBuilder.Entity<Visit>()
                .HasOne(x => x.Vet)
                .WithMany(y => y.Visits)
                .HasForeignKey(v => v.VetId);
            modelBuilder.Entity<Visit>()
                .Property(x => x.Description)
                .HasMaxLength(1000)
                .IsRequired();
            modelBuilder.Entity<Visit>()
                .Property(x => x.VisitType)
                .HasMaxLength(100)
                .IsRequired();

            #endregion

            #region Animal_Medicine
            
            modelBuilder.Entity<Animal_Medicine>().HasKey(x => x.Id);
            modelBuilder.Entity<Animal_Medicine>()
                .HasOne(x => x.Animal)
                .WithMany(y => y.Animals_Medicines)
                .HasForeignKey(c => c.AnimalId);
            modelBuilder.Entity<Animal_Medicine>()
                .HasOne(x => x.Medicine)
                .WithMany(y => y.Animals_Medicines)
                .HasForeignKey(c => c.MedicineId);
            
            #endregion
        }


    }
}

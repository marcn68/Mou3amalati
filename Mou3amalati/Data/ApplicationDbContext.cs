using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mou3amalati.Models;

namespace Mou3amalati.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<DocumentStatus> DocumentStatuses { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<CivilStatus> CivilStatuses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<DocumentRequestStatus> DocumentRequestStatuses { get; set; }
        public DbSet<DocumentRequest> DocumentRequests { get; set; }
        public DbSet<LifeStatus> LifeStatuses { get; set; }
        public DbSet<WorkFlow> WorkFlows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Citizen>()
                .HasOne(c => c.OriginAddress)
                .WithMany(a => a.OriginAddressCitizens)
                .HasForeignKey(c => c.OriginAddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Citizen>()
                .HasOne(c => c.ResidenceAddress)
                .WithMany(a => a.ResidenceAddressCitizens)
                .HasForeignKey(c => c.ResidenceAddressId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<DocumentRequest>()
                .HasOne(d => d.CurrentAssignedToCitizen)
                .WithMany(c => c.DocsAssigned)
                .HasForeignKey(d => d.CurrentAssignedToCitizenId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<DocumentRequest>()
                .HasOne(d => d.RequestedByCitizen)
                .WithMany(c => c.DocsRequested)
                .HasForeignKey(d => d.RequestedByCitizenId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Citizen>()
                .HasOne(c => c.ApplicationIdentityUser)
                .WithOne(a => a.Citizen)
                .HasForeignKey<Citizen>(c => c.ApplicationIdentityUserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }



    }
}
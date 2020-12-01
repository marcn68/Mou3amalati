using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mou3amalati.Models;

namespace Mou3amalati.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<CivilStatus> CivilStatuses { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<DocumentRequestStatus> DocumentRequestStatuses { get; set; }
        public DbSet<DocumentRequest> DocumentRequests { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<FamilyMember> FamilyMembers { get; set; }
        public DbSet<FamilyRole> FamilyRoles { get; set; }
    }
}
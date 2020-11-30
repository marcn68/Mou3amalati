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
        public DbSet<Documents> Document { get; set; }
        public DbSet<Religion> Religion { get; set; }
        public DbSet<CivilStatus> CivilStatus { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<BloodType> BloodType { get; set; }
        public DbSet<DocumentRequestStatus> DocumentRequestStatus { get; set; }
        public DbSet<DocumentRequest> DocumentRequest { get; set; }
    }
}
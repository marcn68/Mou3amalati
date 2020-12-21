using Microsoft.EntityFrameworkCore;
using Mou3amalati.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class SQLCitizenRepository : ICitizenRepository
    {
        private readonly ApplicationDbContext context;

        public SQLCitizenRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Citizen AddCitizen(Citizen Citizen)
        {
            context.Citizens.Add(Citizen);
            context.SaveChanges();
            return Citizen;
        }

        public Citizen Delete(string Id)
        {
            var citizen = context.Citizens.Find(Id);
            if (citizen != null)
            {
                context.Citizens.Remove(citizen);
                context.SaveChanges();
            }
            return citizen;
        }

        public IEnumerable<Citizen> GetAllCitizens()
        {
            return context.Citizens
                 .Include(c => c.Religion)
                 .Include(c => c.CivilStatus)
                 .Include(c => c.BloodType)
                 .Include(c => c.Gender)
                 .Include(c => c.LifeStatus)
                 .Include(c => c.OriginAddress)
                 .Include(c => c.ResidenceAddress)
                 .Include(c => c.ApplicationIdentityUser);
        }

        public Citizen GetCitizen(string Id)
        {
            return context.Citizens
                 .Include(c => c.Religion)
                 .Include(c => c.CivilStatus)
                 .Include(c => c.BloodType)
                 .Include(c => c.Gender)
                 .Include(c => c.LifeStatus)
                 .Include(c => c.OriginAddress)
                 .Include(c => c.ResidenceAddress)
                 .Include(c => c.ApplicationIdentityUser)
                 .FirstOrDefault(c => c.Id == Id);
        }

        public Citizen Update(Citizen CitizenChanges)
        {
            var citizen = context.Citizens.Attach(CitizenChanges);
            citizen.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return CitizenChanges;
        }
    }
}

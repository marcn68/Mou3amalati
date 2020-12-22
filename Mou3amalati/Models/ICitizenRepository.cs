using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public interface ICitizenRepository
    {
        Citizen GetCitizen(string Id);
        IEnumerable<Citizen> GetAllCitizens();
        Citizen AddCitizen(Citizen Citizen);
        Citizen Update(Citizen CitizenChanges);
        Citizen Delete(string Id);
    }
}

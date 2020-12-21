using Microsoft.AspNetCore.Mvc.Rendering;
using Mou3amalati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.ViewModels
{
    public class CitizensCreateViewModel
    {
        public Citizen Citizen { get; set; }
        public SelectList BloodTypes { get; set; }
        public SelectList CivilStatuses { get; set; }
        public SelectList Religions { get; set; }
        public SelectList LifeStatuses { get; set; }
        public SelectList Genders { get; set; }

    }
}

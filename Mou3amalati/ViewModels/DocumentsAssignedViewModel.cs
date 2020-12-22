using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.ViewModels
{
    public class DocumentsAssignedViewModel
    {
        public SelectList roleList { get; set; }
        public string SelectedRoleCitizen { get; set; }
        public string SelectedText { get; set; }
    }
}

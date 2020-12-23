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
        public string RoleName { get; set; }
        public string SelectedRoleCitizenId { get; set; }
        public int DocRequestId { get; set; }
        public bool isLast { get; set; } = false;
        public int DocumentId { get; set; }
    }
}

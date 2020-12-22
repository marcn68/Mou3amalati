using Microsoft.AspNetCore.Mvc.Rendering;
using Mou3amalati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.ViewModels
{
    public class DocumentsEditViewModel
    {
        public Document Document { get; set; }
        public SelectList Roles { get; set; }
    }
}

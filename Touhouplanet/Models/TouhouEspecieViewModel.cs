using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Touhouplanet.Models
{
    public class TouhouEspecieViewModel
    {
        public List<Touhou> Touhous { get; set; }
        public SelectList Especies { get; set; }
        public string TouhouEspecie { get; set; }
        public string SearchString { get; set; }
    }
}

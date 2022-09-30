using System;
using System.Collections.Generic;

namespace TechPartsWebSite.Entities.SistemaNacional
{
    public partial class StkFamilium
    {
        public StkFamilium()
        {
            StkItems = new HashSet<StkItem>();
        }

        public string Id { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? MasterFormula { get; set; }
        public string? MasterReceta { get; set; }
        public string? MasterEspecif { get; set; }
        public string? MasterProceso { get; set; }
        public int? Orden { get; set; }

        public virtual ICollection<StkItem> StkItems { get; set; }
    }
}

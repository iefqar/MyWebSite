using System;
using System.Collections.Generic;

namespace TechPartsWebSite.Entities.SistemaNacional
{
    public partial class StkGrupo
    {
        public StkGrupo()
        {
            StkItems = new HashSet<StkItem>();
            StkSubgrupos = new HashSet<StkSubgrupo>();
        }

        public string Grupo { get; set; } = null!;
        public int? Orden { get; set; }

        public virtual ICollection<StkItem> StkItems { get; set; }
        public virtual ICollection<StkSubgrupo> StkSubgrupos { get; set; }
    }
}

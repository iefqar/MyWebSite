using System;
using System.Collections.Generic;

namespace TechPartsWebSite.Entities.SistemaNacional
{
    public partial class StkSubgrupo
    {
        public StkSubgrupo()
        {
            StkItems = new HashSet<StkItem>();
        }

        public string Subgrupo { get; set; } = null!;
        public string? Grupo { get; set; }
        public int? Orden { get; set; }

        public virtual StkGrupo? GrupoNavigation { get; set; }
        public virtual ICollection<StkItem> StkItems { get; set; }
    }
}

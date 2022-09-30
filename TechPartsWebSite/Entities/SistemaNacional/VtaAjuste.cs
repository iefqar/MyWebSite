using System;
using System.Collections.Generic;

namespace TechPartsWebSite.Entities.SistemaNacional
{
    public partial class VtaAjuste
    {
        public VtaAjuste()
        {
            VtaAjusteItems = new HashSet<VtaAjusteItem>();
        }

        public string Id { get; set; } = null!;
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Porcentaje { get; set; }
        public decimal? Importe { get; set; }
        public decimal? Cantidad { get; set; }
        public int? Orden { get; set; }

        public virtual ICollection<VtaAjusteItem> VtaAjusteItems { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TechPartsWebSite.Entities.SistemaNacional
{
    public partial class StkExistencium
    {
        public string Deposito { get; set; } = null!;
        public string Item { get; set; } = null!;
        public decimal? Cantidad { get; set; }
        public decimal? Produccion { get; set; }
        public decimal? Comprometido { get; set; }
        public string? Ubicacion { get; set; }

        public virtual StkItem ItemNavigation { get; set; } = null!;
    }
}

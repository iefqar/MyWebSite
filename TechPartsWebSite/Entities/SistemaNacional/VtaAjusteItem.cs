using System;
using System.Collections.Generic;

namespace TechPartsWebSite.Entities.SistemaNacional
{
    public partial class VtaAjusteItem
    {
        public string Tipo { get; set; } = null!;
        public string Comprobante { get; set; } = null!;
        public int Linea { get; set; }
        public string Ajuste { get; set; } = null!;
        public decimal? Porcentaje { get; set; }
        public decimal? Importe { get; set; }
        public decimal? Cantidad { get; set; }

        public virtual VtaAjuste AjusteNavigation { get; set; } = null!;
    }
}

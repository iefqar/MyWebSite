using System;
using System.Collections.Generic;

namespace TechPartsWebSite.Entities.SistemaNacional
{
    public partial class StkFormula
    {
        public string Item { get; set; } = null!;
        public decimal? CantidadItem { get; set; }
        public string Componente { get; set; } = null!;
        public decimal? CantidadComp { get; set; }

        public virtual StkItem ComponenteNavigation { get; set; } = null!;
        public virtual StkItem ItemNavigation { get; set; } = null!;
    }
}

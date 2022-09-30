using System;
using System.Collections.Generic;

namespace TechPartsWebSite.Entities.SistemaNacional
{
    public partial class VtaComboItem
    {
        public string Combo { get; set; } = null!;
        public int Linea { get; set; }
        public string? Item { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public bool? Ivainc { get; set; }
        public int? Decimales { get; set; }
        public decimal? Importe { get; set; }
        public decimal? Alicuota { get; set; }
        public decimal? Iva { get; set; }
        public decimal? Ajuste { get; set; }
        public decimal? AjusteNeto { get; set; }
        public decimal? AjusteIva { get; set; }
        public string? Moneda { get; set; }
        public decimal? Cotizacion { get; set; }

        public virtual VtaCombo ComboNavigation { get; set; } = null!;
        public virtual StkItem? ItemNavigation { get; set; }
    }
}

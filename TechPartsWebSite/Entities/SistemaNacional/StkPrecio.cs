using System;
using System.Collections.Generic;

namespace TechPartsWebSite.Entities.SistemaNacional
{
    public partial class StkPrecio
    {
        public string Lista { get; set; } = null!;
        public string Item { get; set; } = null!;
        public decimal Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Aumento { get; set; }
        public decimal? Ganancia { get; set; }
        public decimal? Preciovta { get; set; }
        public decimal? Alicuota { get; set; }
        public string? Moneda { get; set; }
        public string? Calculo { get; set; }
        public decimal? Ajuste { get; set; }
        public decimal? AjustePrecio { get; set; }
        public DateOnly? Fecha { get; set; }

        public virtual StkItem ItemNavigation { get; set; } = null!;
        public virtual StkListum ListaNavigation { get; set; } = null!;
    }
}

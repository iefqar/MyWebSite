using System;
using System.Collections.Generic;

namespace TechPartsWebSite.Entities.SistemaNacional
{
    public partial class VtaCombo
    {
        public VtaCombo()
        {
            VtaComboItems = new HashSet<VtaComboItem>();
        }

        public string Id { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Grupo { get; set; }
        public DateOnly? Fecha { get; set; }
        public byte[]? Foto { get; set; }
        public string? Moneda { get; set; }
        public decimal? Cotizacion { get; set; }
        public string? Lista { get; set; }
        public decimal? AjusteLista { get; set; }
        public string? AjusteTipo { get; set; }
        public decimal? Ajuste { get; set; }
        public string? Observaciones { get; set; }
        public decimal? Neto { get; set; }
        public decimal? Exento { get; set; }
        public decimal? Nogravado { get; set; }
        public decimal? Iva { get; set; }
        public decimal? Total { get; set; }
        public int? Orden { get; set; }

        public virtual StkListum? ListaNavigation { get; set; }
        public virtual ICollection<VtaComboItem> VtaComboItems { get; set; }
    }
}

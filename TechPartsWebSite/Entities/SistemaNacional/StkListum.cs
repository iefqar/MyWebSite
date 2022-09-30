using System;
using System.Collections.Generic;

namespace TechPartsWebSite.Entities.SistemaNacional
{
    public partial class StkListum
    {
        public StkListum()
        {
            InverseListaPadreNavigation = new HashSet<StkListum>();
            StkPrecios = new HashSet<StkPrecio>();
            VtaClientes = new HashSet<VtaCliente>();
            VtaCombos = new HashSet<VtaCombo>();
        }

        public string Id { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Moneda { get; set; }
        public bool? IvaIncluido { get; set; }
        public decimal? Alicuota { get; set; }
        public int? Decimales { get; set; }
        public int? DecimalesCosto { get; set; }
        public decimal? RedondeoGcia { get; set; }
        public decimal? RedondeoPvta { get; set; }
        public decimal? RedondeoTotal { get; set; }
        public string? Round { get; set; }
        public DateOnly? Fecha { get; set; }
        public int? Orden { get; set; }
        public string? ListaPadre { get; set; }
        public bool? Visible { get; set; }

        public virtual StkListum? ListaPadreNavigation { get; set; }
        public virtual ICollection<StkListum> InverseListaPadreNavigation { get; set; }
        public virtual ICollection<StkPrecio> StkPrecios { get; set; }
        public virtual ICollection<VtaCliente> VtaClientes { get; set; }
        public virtual ICollection<VtaCombo> VtaCombos { get; set; }
    }
}

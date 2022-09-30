using System;
using System.Collections.Generic;

namespace TechPartsWebSite.Entities.SistemaNacional
{
    public partial class StkItem
    {
        public StkItem()
        {
            StkExistencia = new HashSet<StkExistencium>();
            StkFormulaComponenteNavigations = new HashSet<StkFormula>();
            StkFormulaItemNavigations = new HashSet<StkFormula>();
            StkPrecios = new HashSet<StkPrecio>();
            VtaComboItems = new HashSet<VtaComboItem>();
        }

        public string Id { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Presentacion { get; set; }
        public string? Grupo { get; set; }
        public string? Subgrupo { get; set; }
        public string? Tipo { get; set; }
        public string? Barcode { get; set; }
        public string? Familia { get; set; }
        public string? Master { get; set; }
        public string? Unidad { get; set; }
        public int? Decimales { get; set; }
        public decimal? Peso { get; set; }
        public decimal? StockMinimo { get; set; }
        public DateOnly? Vencimiento { get; set; }
        public int? VtoMeses { get; set; }
        public string? Rubro { get; set; }
        public decimal? FactorVta { get; set; }
        public string? UnidadVta { get; set; }
        public int? DecimalesVta { get; set; }
        public string? Auxiliar1Vta { get; set; }
        public string? Unidad1Vta { get; set; }
        public int? Decimales1Vta { get; set; }
        public string? Auxiliar2Vta { get; set; }
        public string? Unidad2Vta { get; set; }
        public int? Decimales2Vta { get; set; }
        public string? Auxiliar3Vta { get; set; }
        public string? Unidad3Vta { get; set; }
        public int? Decimales3Vta { get; set; }
        public decimal? FactorCmp { get; set; }
        public string? UnidadCmp { get; set; }
        public int? DecimalesCmp { get; set; }
        public string? Auxiliar1Cmp { get; set; }
        public string? Unidad1Cmp { get; set; }
        public int? Decimales1Cmp { get; set; }
        public string? Auxiliar2Cmp { get; set; }
        public string? Unidad2Cmp { get; set; }
        public int? Decimales2Cmp { get; set; }
        public string? Auxiliar3Cmp { get; set; }
        public string? Unidad3Cmp { get; set; }
        public int? Decimales3Cmp { get; set; }
        public string? UnidadFex { get; set; }
        public string? ItemMatrix { get; set; }
        public string? UnidadMatrix { get; set; }
        public byte[]? Foto { get; set; }
        public string? Observaciones { get; set; }
        public bool? Stock { get; set; }
        public bool? Compra { get; set; }
        public bool? Venta { get; set; }
        public int? Orden { get; set; }

        public virtual StkFamilium? FamiliaNavigation { get; set; }
        public virtual StkGrupo? GrupoNavigation { get; set; }
        public virtual StkSubgrupo? SubgrupoNavigation { get; set; }
        public virtual ICollection<StkExistencium> StkExistencia { get; set; }
        public virtual ICollection<StkFormula> StkFormulaComponenteNavigations { get; set; }
        public virtual ICollection<StkFormula> StkFormulaItemNavigations { get; set; }
        public virtual ICollection<StkPrecio> StkPrecios { get; set; }
        public virtual ICollection<VtaComboItem> VtaComboItems { get; set; }
    }
}

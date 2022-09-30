using System;
using System.Collections.Generic;

namespace TechPartsWebSite.Entities.SistemaNacional
{
    public partial class VtaCliente
    {
        public string Id { get; set; } = null!;
        public string? RazonSocial { get; set; }
        public string? NombreFantasia { get; set; }
        public string? Grupo { get; set; }
        public string? TipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? NumeroIb { get; set; }
        public string? CondicionIva { get; set; }
        public string? Actividad { get; set; }
        public string? Direccion { get; set; }
        public string? Localidad { get; set; }
        public string? Provincia { get; set; }
        public string? Pais { get; set; }
        public string? Cpa { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Webpage { get; set; }
        public string? Contacto { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public DateOnly? FechaAlta { get; set; }
        public DateOnly? FechaBaja { get; set; }
        public int? Orden { get; set; }
        public decimal? Nota { get; set; }
        public string? Observaciones { get; set; }
        public string? Tipo { get; set; }
        public string? Letra { get; set; }
        public short? Punto { get; set; }
        public string? Modelo { get; set; }
        public string? TipoN { get; set; }
        public string? LetraN { get; set; }
        public short? PuntoN { get; set; }
        public string? ModeloN { get; set; }
        public string? Moneda { get; set; }
        public string? Lista { get; set; }
        public decimal? AjusteLista { get; set; }
        public decimal? AjusteListaN { get; set; }
        public string? AjusteTipo { get; set; }
        public string? AjusteTipoN { get; set; }
        public decimal? Ajuste { get; set; }
        public decimal? AjusteN { get; set; }
        public string? Rubro { get; set; }
        public string? CondicionVenta { get; set; }
        public string? CondicionVentaN { get; set; }
        public string? Destino { get; set; }
        public string? Transporte { get; set; }
        public string? Trabajador { get; set; }
        public decimal? ComisionVenta { get; set; }
        public decimal? ComisionVenta1 { get; set; }
        public decimal? ComisionCobro { get; set; }
        public decimal? ComisionCobro1 { get; set; }
        public string? ComprobanteImp { get; set; }
        public string? ComprobanteAdj { get; set; }
        public string? PagoElectronico { get; set; }
        public string? FexIdimpositivo { get; set; }
        public string? ObsFactura { get; set; }
        public decimal? CtacteSaldo { get; set; }
        public DateOnly? CtacteFecha { get; set; }
        public decimal? CtacteLimite { get; set; }
        public decimal? CtacteSaldoN { get; set; }
        public DateOnly? CtacteFechaN { get; set; }
        public decimal? CtacteLimiteN { get; set; }
        public string? ModeloAsiento { get; set; }
        public string? ModeloAsientoCobro { get; set; }
        public ulong? Color { get; set; }

        public virtual StkListum? ListaNavigation { get; set; }
    }
}

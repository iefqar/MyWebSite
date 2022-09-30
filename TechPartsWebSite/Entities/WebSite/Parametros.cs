namespace TechPartsWebSite.Entities.WebSite
{
    public class Parametros
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Sucursal { get; set; }
        public string RazonSocial { get; set; }
        public string Domicilio { get; set; }
        public string CodigoPostal { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string Cuit { get; set; }
        public double IVAInscripto { get; set; }
        public double IVANoInscripto { get; set; }
        public double CotizacionDolar { get; set; }
        public string UltimaActualizacion { get; set; }
        public string EMail { get; set; }
        public string FTPUser { get; set; }
        public string FtpServer { get; set; }
        public string FtpPass { get; set; }
        public string PaginaOfertas { get; set; }
        public string PaginaNovedades { get; set; }
        public string PaginaActualizaciones { get; set; }
        public DateTime fecha_hora { get; set; }
    }
}

using TechPartsWebSite.Entities.SistemaNacional;

namespace TechPartsWebSite.Controllers.DTOs
{
    //Data-Transfer Object
    public class ItemDTO
    {
        public string Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Grupo { get; set; }
        public string? Subgrupo { get; set; }
        public ICollection<StkPrecio> Stkprecio { get; set; }
        public StkFamilium? FamiliaNavigation { get; set; }
    }
}

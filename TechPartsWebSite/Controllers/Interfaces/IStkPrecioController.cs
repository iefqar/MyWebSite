using TechPartsWebSite.Entities.SistemaNacional;

namespace TechPartsWebSite.Controllers.Interfaces
{
    public interface IStkPrecioController
    {
        Task<IEnumerable<StkPrecio>> GetAllPrecio();
        Task<StkPrecio> GetPrecio(int id);
        Task<bool> InsertPrecio(StkPrecio precio);
        Task<bool> UpdatePrecio(StkPrecio precio);
        Task<bool> DeletePrecio(int id);

        Task<bool> SavePrecio(StkPrecio precio);
    }
}

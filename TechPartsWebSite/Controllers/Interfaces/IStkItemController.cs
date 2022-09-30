using TechPartsWebSite.Controllers.DTOs;
using TechPartsWebSite.Entities.SistemaNacional;

namespace TechPartsWebSite.Controllers.Interfaces
{
    public interface IStkItemController
    {
        Task<IEnumerable<ItemDTO>> Get();
        Task<IEnumerable<StkItem>> GetAllItems();
        Task<StkItem> GetItem(int id);
        Task<bool> InsertItem(StkItem item);
        Task<bool> UpdateItem(StkItem item);
        Task<bool> DeleteItem(int id);

        Task<bool> SaveItems(StkItem item);
    }
}

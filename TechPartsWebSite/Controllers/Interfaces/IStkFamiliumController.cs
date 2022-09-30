using TechPartsWebSite.Entities.SistemaNacional;

namespace TechPartsWebSite.Controllers.Interfaces
{
    public interface IStkFamiliumController
    {
        Task<IEnumerable<StkFamilium>> GetAllFamilias();
        Task<StkFamilium> GetFamilia(int id);
        Task<bool> InsertFamilia(StkFamilium familia);
        Task<bool> UpdateFamilia(StkFamilium familia);
        Task<bool> DeleteFamilia(int id);

        Task<bool> SaveFamilias(StkFamilium familia);
    }
}

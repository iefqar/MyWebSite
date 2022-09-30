using TechPartsWebSite.Entities.SistemaNacional;

namespace TechPartsWebSite.Controllers.Interfaces
{
    public interface IStkExistenciumController
    {
        Task<IEnumerable<StkExistencium>> GetAllExistencia();
        Task<StkExistencium> GetExistencia(string id);
        Task<bool> InsertExistencia(StkExistencium existencia);
        Task<bool> UpdateExistencia(StkExistencium existencia);
        Task<bool> DeleteExistencia(string id);

        Task<bool> SaveExistencia(StkExistencium existencia);
    }
}

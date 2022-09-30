using Microsoft.EntityFrameworkCore;
using TechPartsWebSite.Controllers.Interfaces;
using TechPartsWebSite.Data;
using TechPartsWebSite.Entities.SistemaNacional;

namespace TechPartsWebSite.Controllers
{
    public class StkExistenciumController : IStkExistenciumController
    {

        private readonly dariodbContext _context;
        public StkExistenciumController(dariodbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteExistencia(string id)
        {
            var existencia = await _context.StkExistencia.FindAsync(id);
            _context.StkExistencia.Remove(existencia);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<StkExistencium>> GetAllExistencia()
        {
            return await _context.StkExistencia.ToListAsync();
        }

        public async Task<StkExistencium> GetExistencia(string id)
        {
            return await _context.StkExistencia.FindAsync(id);
        }

        public async Task<bool> InsertExistencia(StkExistencium existencia)
        {
            _context.StkExistencia.Add(existencia);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveExistencia(StkExistencium existencia)
        {
            if (await ChequearSiExiste(existencia) is true)
                return await UpdateExistencia(existencia);
            else
                return await InsertExistencia(existencia);
        }

        public async Task<bool> UpdateExistencia(StkExistencium existencia)
        {
            _context.Entry(existencia).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<bool> ChequearSiExiste(StkExistencium existencia)
        {
            var objeto = await GetExistencia(existencia.Deposito);

            if (objeto is null)
                return false;
            else
                return true;
        }

    }
}

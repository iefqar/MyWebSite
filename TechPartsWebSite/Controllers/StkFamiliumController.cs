using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechPartsWebSite.Controllers.Interfaces;
using TechPartsWebSite.Data;
using TechPartsWebSite.Entities.SistemaNacional;

namespace TechPartsWebSite.Controllers
{
    public class StkFamiliumController : IStkFamiliumController
    {

        private readonly dariodbContext _context;
        public StkFamiliumController(dariodbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteFamilia(int id)
        {
            try
            {
                StkFamilium? familia = await _context.StkFamilia.FindAsync(id);
                if (familia != null)
                {
                    _context.StkFamilia.Remove(familia);
                    return await _context.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new ArgumentNullException();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<StkFamilium>> GetAllFamilias()
        {
            try
            {
                return await _context.StkFamilia.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<StkFamilium> GetFamilia(int id)
        {
            try
            {
                StkFamilium? familia = await _context.StkFamilia.FindAsync(id);
                if (familia != null)
                {
                    return familia;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InsertFamilia(StkFamilium familia)
        {
            _context.StkFamilia.Add(familia);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveFamilias(StkFamilium familia)
        {
            if (familia.Id != "0")
                return await UpdateFamilia(familia);
            else
                return await InsertFamilia(familia);
        }

        public async Task<bool> UpdateFamilia(StkFamilium familia)
        {
            _context.Entry(familia).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

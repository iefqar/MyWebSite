using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechPartsWebSite.Controllers.DTOs;
using TechPartsWebSite.Controllers.Interfaces;
using TechPartsWebSite.Data;
using TechPartsWebSite.Entities.SistemaNacional;

namespace TechPartsWebSite.Controllers
{
    public class StkPrecioController : IStkPrecioController
    {

        private readonly dariodbContext _context;
        public StkPrecioController(dariodbContext context)
        {
            _context = context;
        }

        //public async Task<ActionResult<ItemsVisualizarDTO>> Get()
        //{
        //    try
        //    {
        //        var ListaDeItems = await _context.StkItems.Select(i =>
        //       new StkItem
        //       {
        //           Descripcion = i.Descripcion,
        //           Subgrupo = i.Subgrupo,
        //           Grupo = i.Grupo,
        //           Familia = i.Familia,
        //           StkPrecios = i.StkPrecios.Select(p =>
        //           new StkPrecio { Item = p.Item, Precio = p.Precio }).ToList()
        //       }).Include(x => x.StkPrecios).ThenInclude(x=> x.Item)
        //         .Include(x => x.StkPrecios).ThenInclude(x=> x.Precio)
        //         .ToListAsync();

        //       // var listaDePrecios = await _context.StkPrecios.Select(p =>
        //       //new StkPrecio
        //       //{
        //       //    Item = p.Item,
        //       //    Precio = p.Precio,
        //       //}).ToListAsync();

        //        var model = new ItemsVisualizarDTO();
        //        model.Item = ListaDeItems;
        //        //model.Precio = ListaDeItems.
        //        return model;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public async Task<bool> DeletePrecio(int id)
        {
            try
            {
                StkPrecio? precio = await _context.StkPrecios.FindAsync(id);
                if (precio != null)
                {
                    _context.StkPrecios.Remove(precio);
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

        public async Task<IEnumerable<StkPrecio>> GetAllPrecio()
        {
            try
            {

                var ListaDeItems = await _context.StkPrecios.ToListAsync();

                return ListaDeItems;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task<IEnumerable<StkItem>> GetAllItems()
        //{
        //    try
        //    {

        //        var ListaDeItems = await _context.StkItems.Select(i =>
        //        new StkItem
        //        {
        //            Descripcion = i.Descripcion,
        //            Subgrupo = i.Subgrupo,
        //            Grupo = i.Grupo,
        //            Familia = i.Familia,
        //            StkPrecios = i.StkPrecios.Select(p =>
        //            new StkPrecio { Item = p.Item, Precio = p.Precio }).ToList()
        //        }).ToListAsync();

        //        return await _context.StkItems.ToListAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public async Task<StkPrecio> GetPrecio(int id)
        {
            try
            {
                StkPrecio? precio = await _context.StkPrecios.FindAsync(id);
                if (precio != null)
                {
                    return precio;
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

        public async Task<bool> InsertPrecio(StkPrecio precio)
        {
            _context.StkPrecios.Add(precio);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SavePrecio(StkPrecio precio)
        {
            if (precio.Item != "0")
                return await UpdatePrecio(precio);
            else
                return await InsertPrecio(precio);
        }

        public async Task<bool> UpdatePrecio(StkPrecio precio)
        {
            _context.Entry(precio).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

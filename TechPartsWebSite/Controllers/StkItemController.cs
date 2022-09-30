using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechPartsWebSite.Controllers.DTOs;
using TechPartsWebSite.Controllers.Interfaces;
using TechPartsWebSite.Data;
using TechPartsWebSite.Entities.CatalogoTechParts;
using TechPartsWebSite.Entities.SistemaNacional;

namespace TechPartsWebSite.Controllers
{
    public class StkItemController : IStkItemController
    {

        private readonly dariodbContext _context;
        private readonly IMapper _mapper;

        public StkItemController(dariodbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ItemDTO>> Get()
        {
            return await _context.StkItems.ProjectTo<ItemDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        //public async Task<ActionResult<ItemDTO>> Get()
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
        //       }).Include(x => x.StkPrecios).ThenInclude(x => x.Item)
        //         .Include(x => x.StkPrecios).ThenInclude(x => x.Precio)
        //         .AsNoTracking()
        //         .ToListAsync();

        //        // var listaDePrecios = await _context.StkPrecios.Select(p =>
        //        //new StkPrecio
        //        //{
        //        //    Item = p.Item,
        //        //    Precio = p.Precio,
        //        //}).ToListAsync();

        //        var model = new ItemDTO();
        //        model.Item = ListaDeItems;
        //        //model.Precio = ListaDeItems.
        //        return model;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public async Task<bool> DeleteItem(int id)
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

        public async Task<IEnumerable<StkItem>> GetAllItems()
        {
            try
            {
                var ListaDeItems = await _context.StkItems
                    .ProjectTo<StkItem>(_mapper.ConfigurationProvider)
                    //.Select(a => new ItemDTO
                    //{
                    //    Id = a.Id,
                    //    Descripcion = a.Descripcion,
                    //    Grupo = a.Grupo,
                    //    Subgrupo = a.Subgrupo,
                    //    Stkprecio = a.StkPrecios,
                    //    FamiliaNavigation = a.FamiliaNavigation
                    //}) 
                    .Include(e =>  e.StkPrecios )
                    .Include(f => f.FamiliaNavigation)
                    .ToListAsync();

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

        public async Task<StkItem> GetItem(int id)
        {
            try
            {
                StkItem? item = await _context.StkItems.FindAsync(id);
                if (item != null)
                {
                    return item;
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

        public async Task<bool> InsertItem(StkItem item)
        {
            _context.StkItems.Add(item);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveItems(StkItem item)
        {
            if (item.Id != "0")
                return await UpdateItem(item);
            else
                return await InsertItem(item);
        }

        public async Task<bool> UpdateItem(StkItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

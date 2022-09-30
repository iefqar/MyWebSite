using AutoMapper;
using TechPartsWebSite.Controllers.DTOs;
using TechPartsWebSite.Entities.SistemaNacional;

namespace TechPartsWebSite.Services
{
    public class AutoMapperProfiles : Profile
    {
    private AutoMapperProfiles()
        {
            CreateMap<StkItem, ItemDTO>();
        }
    }
}

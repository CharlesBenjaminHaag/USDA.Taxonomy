using AutoMapper;

namespace USDA.ARS.GRIN.GRINGlobal.API.Web.Profiles
{
    public class SpeciesProfile : Profile
    {
        public SpeciesProfile() { 
            CreateMap<Data.Models.taxonomy_species, Models.SpeciesDTO>();
            CreateMap<Data.Models.taxonomy_species, Models.SpeciesDTOWithoutChildren>();
        }
    }
}

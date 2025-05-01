using AutoMapper;

namespace USDA.ARS.GRIN.GRINGlobal.API.Web.Profiles
{
    public class CommonNameProfile : Profile
    {
        public CommonNameProfile()
        {
            CreateMap<Data.Models.taxonomy_common_name, Models.CommonNameDTO>();
        }
    }
}

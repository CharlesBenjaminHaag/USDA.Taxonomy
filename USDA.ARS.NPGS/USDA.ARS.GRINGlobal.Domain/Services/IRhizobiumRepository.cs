using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRINGlobal.Domain.Models;

namespace USDA.ARS.GRINGlobal.Domain.Services
{
    public interface IRhizobiumRepository
    {
        Task<IEnumerable<RhizobiumDTO>> GetAllRhizobiumAsync(int pageNumber = 1, int pageSize = 10);
        Task<RhizobiumDTO> GetRhizobiumByIdAsync(int id);
        Task<IEnumerable<AccessionDTO>> GetRhizobiumByCriteriaAsync(AccessionCriteriaDTO criteria);
    }
}

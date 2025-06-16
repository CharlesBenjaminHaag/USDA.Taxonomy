using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRINGlobal.Domain.Models;

namespace USDA.ARS.GRINGlobal.Domain.Services
{
    public interface IReferenceRepository
    {
        Task<IEnumerable<CropGermplasmCommitteeDTO>> GetImprovementLevelsAsync(int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<CropGermplasmCommitteeDTO>> GetAvailabilityStatusesAsync(int pageNumber = 1, int pageSize = 10);
        Task<IEnumerable<CropGermplasmCommitteeDTO>> GetSourceTypesAsync(int pageNumber = 1, int pageSize = 10);
    }
}

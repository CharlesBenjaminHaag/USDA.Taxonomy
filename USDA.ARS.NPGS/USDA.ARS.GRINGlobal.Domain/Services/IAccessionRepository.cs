using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRINGlobal.Domain.Models;

namespace USDA.ARS.GRINGlobal.Domain.Services
{
    public interface IAccessionRepository
    { 
        Task<IEnumerable<AccessionDTO>> GetAllAccessionsAsync(int pageNumber = 1, int pageSize = 10);
        Task<AccessionDTO> GetAccessionByIdAsync(int id);
        Task<IEnumerable<AccessionDTO>> GetAccessionsByCriteriaAsync(AccessionCriteriaDTO criteria);
        Task<IEnumerable<TabularReportItemDTO>> GetReportSummaryDiversityAsync();

        Task AddAccessionAsync(AccessionDTO accession);
        Task UpdateAccessionAsync(AccessionDTO accession);
        Task DeleteAccessionAsync(int id);
    }
}

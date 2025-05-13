using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRINGlobal.Data.Models;
using USDA.ARS.GRINGlobal.Domain.Models;

namespace USDA.ARS.GRINGlobal.Domain.Services
{
    public class AccessionRepository : IAccessionRepository
    {
        private readonly gringlobalContext _context;

        public AccessionRepository(gringlobalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task AddAccessionAsync(AccessionDTO accession)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAccessionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AccessionDTO>> GetAccessionsByCriteriaAsync(string criteria)
        {
            return await Task.Run(() =>
             {
                 var accessions = _context.Accessions
                     .Where(a => a.AccessionNumberPart1.Contains(criteria) || a.AccessionNumberPart2.ToString().Contains(criteria) || a.AccessionNumberPart3.Contains(criteria))
                     .Select(a => new AccessionDTO
                     {
                         //AccessionId = a.AccessionId,
                         //AccessionNumberPart1 = a.AccessionNumberPart1,
                         //AccessionNumberPart2 = a.AccessionNumberPart2,
                         //AccessionNumberPart3 = a.AccessionNumberPart3,
                         //IsCore = a.IsCore,
                         //IsBackedUp = a.IsBackedUp,
                         //StatusCode = a.StatusCode,
                         //LifeFormCode = a.LifeFormCode,
                         //ImprovementStatusCode = a.ImprovementStatusCode,
                         //ReproductiveUniformityCode = a.ReproductiveUniformityCode,
                         //InitialReceivedFormCode = a.InitialReceivedFormCode,
                         //InitialReceivedDate = a.InitialReceivedDate,
                         //InitialReceivedDateCode = a.InitialReceivedDateCode,
                         //TaxonomySpeciesId = a.TaxonomySpeciesId,
                         //IsWebVisible = a.IsWebVisible,
                         //Note = a.Note
                     }).ToList();
                 return accessions;
             });
        }

        public Task<AccessionDTO> GetAccessionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccessionDTO>> GetAllAccessionsAsync(int pageNumber = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccessionAsync(AccessionDTO accession)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TabularReportItemDTO>> GetReportSummaryDiversityAsync()
        {
            var report = await _context.Database.SqlQueryRaw<TabularReportItemDTO>("SELECT title_field, total_field FROM vw_GRINGlobal_Rpt_Summary_Diversity ORDER BY title_field").ToListAsync();
            return report;
        }


    }
}

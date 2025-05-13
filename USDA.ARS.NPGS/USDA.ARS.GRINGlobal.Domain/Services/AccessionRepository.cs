using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRINGlobal.Data.Models;
using USDA.ARS.GRINGlobal.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<IEnumerable<AccessionDTO>> GetAccessionsByCriteriaAsync(AccessionCriteriaDTO criteria)
        {
            var accessions = _context.Accessions.AsQueryable();

            if (!String.IsNullOrEmpty(criteria.accession_identifier))
            {
                accessions = accessions.Where(a => 
                    a.AccessionLookup.Contains(criteria.accession_identifier));
            }

            if (!String.IsNullOrEmpty(criteria.scientific_name))
            {
                accessions = accessions.Where(a => 
                    a.TaxonomySpecies.Name.Contains(criteria.scientific_name));
            }

            if (!String.IsNullOrEmpty(criteria.plant_name))
            {
                accessions = accessions.Where(a =>
                    a.Inventories.Any(i => 
                        i.AccessionInvNames.Any(n => 
                            n.PlantName.Contains(criteria.plant_name))));
            }

            if (!String.IsNullOrEmpty(criteria.country_of_origin))
            {
                accessions = accessions.Where(a => 
                    a.AccessionSources.Any(s => 
                        s.Geography.CountryCode == criteria.country_of_origin));
            }

            var totalCount = await accessions.CountAsync();

            int skip = (criteria.startPage - 1) * criteria.pageSize;
            accessions = accessions.Skip(skip).Take(criteria.pageSize);

            return await accessions.
                Select(p => new AccessionDTO
                {
                    id = p.AccessionId,
                    lookup_name = p.AccessionLookup,
                }).ToListAsync();
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

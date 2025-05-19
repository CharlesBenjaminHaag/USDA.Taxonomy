using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRINGlobal.Data.Models;
using USDA.ARS.GRINGlobal.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;

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
            var sql = new StringBuilder("SELECT Accession, Plant_Name, DOI, taxonomy_species_id, Origin, Genebank, Image, Availability, Received, Source_Type, Source_Date, Collection_Site, Improvement_Level InitialReceivedDate FROM gringlobal].dbo].vw_GRINGlobal_Accession_Summary]");

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(criteria.accession_identifier))
            {
                sql.Append(" AND Name LIKE '%' + @name + '%'");
                parameters.Add(new SqlParameter("@accession_identifier", criteria.accession_identifier));
            }

            //if (minAge.HasValue)
            //{
            //    sql.Append(" AND Age >= @minAge");
            //    parameters.Add(new SqlParameter("@minAge", minAge.Value));
            //}

            //// Execute query
            //var results = await context.Database
            //    .SqlQueryRaw<MyDto>(sql.ToString(), parameters.ToArray())
            //    .ToListAsync();

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
            var report = await _context.Database.SqlQueryRaw<TabularReportItemDTO>("SELECT Accession, total_field FROM vw_GRINGlobal_Rpt_Summary_Diversity ORDER BY title_field").ToListAsync();
            return report;
        }


    }
}

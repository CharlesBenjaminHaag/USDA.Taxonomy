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
            var query = _context.AccessionOverviews.AsQueryable();

            if (!String.IsNullOrEmpty(criteria.accession_identifier))
            {
                query = query.Where(v => v.AccessionIdentifier.Contains(criteria.accession_identifier));
            }

            if (!String.IsNullOrEmpty(criteria.plant_name))
            {
                query = query.Where(v => v.PlantName.Contains(criteria.plant_name));
            }

            if (!String.IsNullOrEmpty(criteria.scientific_name))
            {
                query = query.Where(v => v.TaxonomySpeciesName.Contains(criteria.scientific_name));
            }

            if (criteria.genebank_id > 0)
            {
                query = query.Where(v => v.GenebankId == criteria.genebank_id);
            }

            if (!String.IsNullOrEmpty(criteria.genebank_name))
            {
                query = query.Where(v => v.GenebankName.Contains(criteria.genebank_name));
            }

            if (!String.IsNullOrEmpty(criteria.country_of_origin))
            {
                query = query.Where(v => v.SourceCountryCode == criteria.country_of_origin);
            }

            if (criteria.received_year > 0)
            {
                query = query.Where(v => v.ReceivedYear == criteria.received_year);
            }

            var results = await query
                .Select(r => new AccessionDTO
                {
                    accession_id = r.AccessionId,
                    accession_identifier = r.AccessionIdentifier,
                    plant_name = r.PlantName,
                    taxonomy_species_id = r.TaxonomySpeciesId,
                    taxonomy_species_name = r.TaxonomySpeciesName,
                    origin_location = r.SourceCountryName,
                    genebank_name = r.GenebankName,
                    image_url = r.ImageUrl,
                    availability_status = r.AvailabilityStatus,
                    improvement_level = r.ImprovementLevel
                    })
                .OrderBy(a => a.accession_id).Skip(criteria.pageSize * (criteria.startPage - 1)).ToListAsync();
            return results;



            //var sql = new StringBuilder("SELECT * FROM FROM vw_GRINGlobal_Accession_Overview WHERE 1=1 ");

            //var parameters = new List<SqlParameter>();

            //if (!string.IsNullOrEmpty(criteria.accession_identifier))
            //{
            //    sql.Append(" AND accession_identifier LIKE @name");
            //    parameters.Add(new SqlParameter("@accession_identifier", $"%{criteria.accession_identifier}%"));
            //}

            //if (!string.IsNullOrEmpty(criteria.scientific_name))
            //{
            //    sql.Append(" AND taxonomy_species_name LIKE @taxonomy_species_name");
            //    parameters.Add(new SqlParameter("@taxonomy_species_name", $"%{criteria.scientific_name}%"));
            //}

            //if (!string.IsNullOrEmpty(criteria.plant_name))
            //{
            //    sql.Append(" AND plant_name LIKE @plant_name");
            //    parameters.Add(new SqlParameter("@plant_name", $"%{criteria.plant_name}%"));
            //}

            //if (!string.IsNullOrEmpty(criteria.genebank_name))
            //{
            //    sql.Append(" AND genebank_name LIKE @genebank_name");
            //    parameters.Add(new SqlParameter("@genebank_name", criteria.genebank_name));
            //}

            //if (!string.IsNullOrEmpty(criteria.country_of_origin))
            //{
            //    sql.Append(" AND origin_location LIKE @country_of_origin");
            //    parameters.Add(new SqlParameter("@country_of_origin", criteria.country_of_origin));
            //}

            //var results = await _context.Database
            //    .SqlQueryRaw<AccessionDTO>(sql.ToString(), parameters.ToArray())
            //    .ToListAsync();
            //return results;
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

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
            var sql = new StringBuilder("SELECT accession_name, plant_name, doi, taxonomy_species_id, taxonomy_species_name, origin_location, genebank_name, image_url, availability, received_date, source_type, source_date, source_collection_location, source_location_lat_long, source_location_elevation, source_habitat_description, improvement_level, narrative, accession_id, initial_received_date FROM vw_GRINGlobal_Accession_Summary WHERE 1=1 ");

            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(criteria.accession_identifier))
            {
                sql.Append(" AND accession_name LIKE @name");
                parameters.Add(new SqlParameter("@accession_identifier", $"%{criteria.accession_identifier}%"));
            }

            if (!string.IsNullOrEmpty(criteria.scientific_name))
            {
                sql.Append(" AND taxonomy_species_name LIKE @taxonomy_species_name");
                parameters.Add(new SqlParameter("@taxonomy_species_name", $"%{criteria.scientific_name}%"));
            }
            if (!string.IsNullOrEmpty(criteria.genebank_name))
            {
                sql.Append(" AND genebank_name LIKE @genebank_name");
                parameters.Add(new SqlParameter("@genebank_name", criteria.genebank_name));
            }
            var results = await _context.Database
                .SqlQueryRaw<AccessionDTO>(sql.ToString(), parameters.ToArray())
                .ToListAsync();
            return results;
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

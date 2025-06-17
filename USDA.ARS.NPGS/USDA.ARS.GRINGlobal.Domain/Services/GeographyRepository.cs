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
    public class GeographyRepository : IGeographyRepository
    {
        private readonly gringlobalContext _context;

        public GeographyRepository(gringlobalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<GeographyDTO>> GetAllCountriesAsync(int pageNumber = 1, int pageSize = 10)
        {
            return await Task.Run(() =>
            {
                var countries = _context.CountryViews
                    .Select(c => new GeographyDTO
                    {
                        geography_id = c.GeographyId,
                        country_code = c.CountryCode,
                        country_name = c.Countryname
                    }).ToList().OrderBy(c => c.country_name);
                return countries;
            });
        }
    }
}

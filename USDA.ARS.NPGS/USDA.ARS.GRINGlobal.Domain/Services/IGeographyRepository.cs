using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRINGlobal.Domain.Models;

namespace USDA.ARS.GRINGlobal.Domain.Services
{
    public interface IGeographyRepository
    {
        Task<IEnumerable<GeographyDTO>> GetAllCountriesAsync(int pageNumber = 1, int pageSize = 10);
    }
}

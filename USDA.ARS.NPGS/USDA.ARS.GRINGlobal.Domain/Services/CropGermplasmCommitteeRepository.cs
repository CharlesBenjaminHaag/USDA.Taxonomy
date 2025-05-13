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
    public class CropGermplasmCommitteeRepository : ICropGermplasmCommitteeRepository
    {
        private readonly gringlobalContext _context;

        public CropGermplasmCommitteeRepository(gringlobalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<CropGermplasmCommitteeDTO>> GetCropGermplasmCommitteesAsync(int pageNumber = 1, int pageSize = 10)
        {
            var cropGermplasmCommitteeCollection = _context.CropGermplasmCommittees as IQueryable<CropGermplasmCommitteeDTO>;

            cropGermplasmCommitteeCollection = (IQueryable<CropGermplasmCommitteeDTO>)_context.CropGermplasmCommittees
                .Select(c => new CropGermplasmCommitteeDTO
                {
                    id = c.CropGermplasmCommitteeId,
                    name = c.CropGermplasmCommitteeName,
                    roster_url = c.RosterUrl
                }).ToListAsync();
            return cropGermplasmCommitteeCollection;   
        }

        
    }
}

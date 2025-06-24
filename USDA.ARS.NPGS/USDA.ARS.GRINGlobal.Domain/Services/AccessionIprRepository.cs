using Microsoft.EntityFrameworkCore;
using USDA.ARS.GRINGlobal.Data.Models;
using USDA.ARS.GRINGlobal.Domain.Models;

namespace USDA.ARS.GRINGlobal.Domain.Services
{
    public class AccessionIprRepository : IAccessionIprRepository
    {
        private readonly gringlobalContext _context;

        public AccessionIprRepository(gringlobalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
       
        public async Task<IEnumerable<AccessionIprDTO>> GetAccessionIprsByCriteriaAsync(AccessionIprCriteriaDTO criteria)
        {
            var query = _context.AccessionIprOverviews.AsQueryable();

            if (criteria.certificate_expired_date > DateTime.MinValue)
            {
                query = query.Where(c => c.ExpiredDate >=  criteria.certificate_expired_date);
            }

            if (!String.IsNullOrEmpty(criteria.status_code))
            {
                query = query.Where(c => c.Note.Contains(criteria.status_code));
            }

            if (!String.IsNullOrEmpty(criteria.type_code))
            {
                query = query.Where(c => c.TypeCode == criteria.type_code);
            }

            if (!String.IsNullOrEmpty(criteria.ipr_crop_name))
            {
                query = query.Where(c => c.IprCropName.Contains(criteria.ipr_crop_name));
            }

            var accessionIprs = await query
                .Select(c => new AccessionIprDTO
                {
                    accession_ipr_id = c.AccessionIprId,
                    accession_id = c.AccessionId,
                    status_code = c.ApplicationStatus,
                    status_description = c.ApplicationStatusDescription,
                    type_code = c.TypeCode,
                    ipr_number = c.IprNumber,
                    ipr_crop_name = c.IprCropName,
                    ipr_full_name = c.IprFullName,
                    certificate_issued_date = c.IssuedDate,
                    certificate_expired_date = c.ExpiredDate,
                    certificate_expired_status = c.ExpirationStatus,
                    accepted_Date = c.AcceptedDate,
                    expected_date = c.ExpectedDate
                })
                .ToListAsync();

            return accessionIprs;

        }
    }
}

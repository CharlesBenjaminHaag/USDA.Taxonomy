using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRINGlobal.Domain.Models;

namespace USDA.ARS.GRINGlobal.Domain.Services
{
    public class AccessionRepository : IAccessionRepository
    {
        public Task AddAccessionAsync(AccessionDTO accession)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAccessionAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<AccessionDTO>> GetAccessionsByCriteriaAsync(string criteria)
        {
            throw new NotImplementedException();
        }
        public Task<AccessionDTO> GetAccessionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<AccessionDTO>> GetAllAccessionsAsync()
        {
            throw new NotImplementedException();
        }
        public Task UpdateAccessionAsync(AccessionDTO accession)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<AccessionDTO>> IAccessionRepository.GetAllAccessionsAsync()
        {
            throw new NotImplementedException();
        }

        Task<AccessionDTO> IAccessionRepository.GetAccessionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<AccessionDTO>> IAccessionRepository.GetAccessionsByCriteriaAsync(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}

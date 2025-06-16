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
    public class CodeValueRepository : ICodeValueRepository
    {
        private readonly gringlobalContext _context;

        public CodeValueRepository(gringlobalContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<CodeValueDTO>> GetCodeValuesAsync(string groupName = "", int pageNumber = 1, int pageSize = 10)
        {
            return await Task.Run(() =>
            {
                var codeValues = _context.CodeValueLookups.Where(c => string.IsNullOrEmpty(groupName) || c.GroupName == groupName)
                    .Select(c => new CodeValueDTO
                    {
                        code_value_id = c.CodeValueId,
                        code_value_lang_id = c.CodeValueLangId,
                        group_name = c.GroupName,
                        value = c.Value,
                        title = c.Title,
                        description = c.Description
                    }).ToList();
                return codeValues;
            });
        }
    }
}

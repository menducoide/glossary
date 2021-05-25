using Glossary.DataTransferObjects.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glossary.Domain.IServices
{
    public interface ITermService
    {
        Task<IEnumerable<TermDto>> List();
        Task<TermDto> GetBy(int id);
        Task<TermDto> GetBy(string name);
        Task<TermDto> Insert(TermDto dto);
        Task Update(int id,TermDto dto);
        Task Remove(int id);
    }
}

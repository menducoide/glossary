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
        Task<IEnumerable<TermDto>> ListBy(string name, int id = 0);
        Task<TermDto> GetBy(int id);
        Task<TermDto> Insert(TermDto dto);
        Task Update(int id,TermDto dto);
        Task Remove(int id);
    }
}

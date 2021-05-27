using Glossary.DataTransferObjects.Models;
using Glossary.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glossary.Test.Stubs
{
    public class TermServiceHappyPathStub : ITermService
    {
        public TermServiceHappyPathStub()
        {
            int id = 1;
            Terms = new List<TermDto>{ new TermDto { TermId = id++, Name = "abyssal plain", Definition = "The ocean floor offshore from the continental margin, usually very flat with a slight slope." },
                new TermDto { TermId = id++, Name = "accrete", Definition = "v.  To  add  terranes  (small  land  masses  or  pieces  of  crust)  to  another, usually larger, land mass." },
                new TermDto { TermId = id++, Name = "alkaline", Definition = "Term  pertaining  to  a  highly  basic,  as  opposed  to  acidic, substance.  For example, hydroxide or carbonate of sodium or potassium." }
            };
        }

        private IList<TermDto> Terms { get; set; }
        public async Task<TermDto> GetBy(int id)
        {
            return Terms.FirstOrDefault();
        }

        public async Task<TermDto> Insert(TermDto dto)
        {            
            dto.TermId = Terms.Count() + 1;
            this.Terms.Add(dto);
            return dto;
        }

        public async Task<IEnumerable<TermDto>> List()
        {
            return Terms;
        }

        public async Task<IEnumerable<TermDto>> ListBy(string name, int id = 0)
        {
             return new List<TermDto>();
        }

        public Task Remove(int id)
        {
            this.Terms.RemoveAt(id - 1);
            return Task.CompletedTask;
        }

        public Task Update(int id, TermDto dto)
        {
            return Task.CompletedTask;
        }
    }
}

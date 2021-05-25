using AutoMapper;
using Glossary.DataTransferObjects.Models;
using Glossary.Domain.IServices;
using Glossary.Persistence.Context;
using Glossary.Persistence.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glossary.Domain.Services
{
    public class TermService : ITermService
    {
        private readonly IMapper _mapper;

        private readonly IBaseRepository<Term> _repository;

        public TermService(IMapper mapper, IBaseRepository<Term> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<TermDto>> List()
        {
            var entities = await _repository.ListBy(s => s.Active == true);
            if (!entities.Any())
            {
                Initialize();
                entities = await _repository.ListBy(s => s.Active == true);
            }
            return _mapper.Map<IEnumerable<TermDto>>(entities);            
        }
        public Task<TermDto> GetBy(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TermDto> GetBy(string name)
        {
            throw new NotImplementedException();
        }

        public Task<TermDto> Insert(TermDto dto)
        {
            throw new NotImplementedException();
        }


        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, TermDto dto)
        {
            throw new NotImplementedException();
        }
        private async Task Initialize()
        {
            var entities = new List<Term> {
                new Term { Name = "abyssal plain" , Definition = "The ocean floor offshore from the continental margin, usually very flat with a slight slope." },
                new Term { Name = "accrete" , Definition = "v.  To  add  terranes  (small  land  masses  or  pieces  of  crust)  to  another, usually larger, land mass." },
                new Term { Name = "alkaline" , Definition = "Term  pertaining  to  a  highly  basic,  as  opposed  to  acidic, substance.  For example, hydroxide or carbonate of sodium or potassium." },
            };
            foreach (var entity in entities)
            {
                await _repository.Insert(entity);
            }
        }
    }
}

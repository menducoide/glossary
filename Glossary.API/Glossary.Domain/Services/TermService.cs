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
                await Initialize();
                entities = await _repository.ListBy(s => s.Active == true);
            }
            return _mapper.Map<IEnumerable<TermDto>>(entities);
        }
        public async Task<IEnumerable<TermDto>> ListBy(string name, int id = 0)
        {
            name = name.ToLower();
            var entities = await _repository.ListBy(s => s.Active == true && s.Name.ToLower() == name && s.TermId != id);
            return _mapper.Map<IEnumerable<TermDto>>(entities);
        }
        public async Task<TermDto> GetBy(int id)
        {
            var entity = await _repository.GetBy(s => s.Active == true && s.TermId == id);
            return _mapper.Map<TermDto>(entity);
        }


        public async Task<TermDto> Insert(TermDto dto)
        {
            Term entity = _mapper.Map<Term>(dto);
            entity = await _repository.Insert(entity);
            dto.TermId = entity.TermId;
            return dto;
        }


        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, TermDto dto)
        {
            Term entity = await _repository.GetById(id);
            _mapper.Map(dto,entity);
            await _repository.Update(entity);
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

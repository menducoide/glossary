using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Glossary.DataTransferObjects.Models;
using Glossary.Persistence.Context;

namespace Glossary.Domain.Mapping
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<Term, TermDto>();
        }
    }
}

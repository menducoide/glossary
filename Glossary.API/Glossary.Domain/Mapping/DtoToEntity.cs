using AutoMapper;
using Glossary.DataTransferObjects.Models;
using Glossary.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glossary.Domain.Mapping
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<TermDto, Term>();
        }
    }
}

using Glossary.Domain.IServices;
using Glossary.Domain.Services;
using Glossary.Persistence.IRepositories;
using Glossary.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glossary.API.Configuration
{
    public static class DependencyInjection
    {
        public static void AddDI(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITermService, TermService>();           
        }
    }
}

using AutoMapper;
using Glossary.API.Configuration;
using Glossary.Domain.IServices;
using Glossary.Domain.Mapping;
using Glossary.Persistence.Context;
using Glossary.Test.DataGenerator;
using Glossary.Test.Stubs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glossary.Test.Fixtures
{
    public class GlossaryAPIFactory : WebApplicationFactory<Glossary.API.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
           {
               services.AddScoped<ITermService, TermServiceHappyPathStub>();
           });
            //builder.Configure(app =>
            //{
            //    using (var serviceScope = app.ApplicationServices.CreateScope())
            //    {
            //        var context = serviceScope.ServiceProvider.GetService<GlossaryDBContext>();
            //        TermDataGenerator.Initialize(context);
            //    }
            //});
        }
    }
}

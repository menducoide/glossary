using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Glossary.Persistence.Context;
using Glossary.Test.Utility.Extensions;
using Glossary.Test.Fixtures;
using Api = Glossary.API;
using Glossary.DataTransferObjects.Models;
using Glossary.Domain.IServices;
using Glossary.Test.Stubs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;

namespace Glossary.Test.API
{
    public class TermsControllerTest : Fixtures.IntegrationTest
    {
        public TermsControllerTest(GlossaryAPIFactory fixture)
          : base(fixture) { }
        private readonly string baseUrl = "/api/v1/terms/";
        [Fact]
        public async Task Get_Should_Retrieve_Terms()
        {
            var terms = await _client.GetAndDeserialize<Term[]>(baseUrl);
            terms.Should().HaveCountGreaterThan(0);
        }
        [Fact]
        public async Task Get_By_Id_Should_Retrieve_Term()
        {
            var term = await _client.GetAndDeserialize<Term>(baseUrl+ "1");
            term.Should().NotBeNull();
        }
        [Fact]
        public async Task Post_Should_ResultOk_Retrieve_Term()
        {
            var term = new TermDto
            {
                Definition = "Test Definition",
                Name = "Test"
            };
            term = await _client.SerializeAndPostAndDeserialize(baseUrl, term);
            term.Should().NotBeNull();
        }
        [Fact]
        public async Task Post_Should_ResultInABadRequest_When_HasMissingFields()
        {
            var term = new TermDto
            {
            };
            var response = await _client.SerializeAndPost(baseUrl, term, false);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Update_Should_ResultOk()
        {
            var term = new TermDto
            {
                Definition = "Test Definition",
                Name = "Test"
            };
            await _client.SerializeAndPut(baseUrl + "1", term);
        }
        [Fact]
        public async Task Delete_Should_ResultOk()
        {             
            var response = await _client.DeleteAsync(baseUrl + "1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Post_Should_ResultInABadRequest_When_HasNotUniqueName()
        {

            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient<ITermService, TermServiceWithExceptionStub>();
                });
            }).CreateClient(new WebApplicationFactoryClientOptions());
            var term = new TermDto
            {
                Definition = "Test Definition",
                Name = "Test"
            };
            var response = await client.SerializeAndPost(baseUrl,term,false);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }   
       

        [Fact]
        public async Task Get_By_Id_Should_ResultNotFound_When_TermNotExist()
        {
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient<ITermService, TermServiceWithExceptionStub>();
                });
            }).CreateClient(new WebApplicationFactoryClientOptions());
            var response = await client.GetAsync(baseUrl + "1");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task Update_Should_ResultInBadRequest_When_HasNotUniqueName()
        {
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient<ITermService, TermServiceWithExceptionStub>();
                });
            }).CreateClient(new WebApplicationFactoryClientOptions());
            var term = new TermDto
            {
                Definition = "Test Definition",
                Name = "Test"
            };
            var response = await client.SerializeAndPut(baseUrl + "1", term, false);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        [Fact]
        public async Task Delete_Should_ResultNotFound_When_TermNotExist()
        {
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddTransient<ITermService, TermServiceWithExceptionStub>();
                });
            }).CreateClient(new WebApplicationFactoryClientOptions());
            var response = await client.DeleteAsync(baseUrl + "1");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

    }
}

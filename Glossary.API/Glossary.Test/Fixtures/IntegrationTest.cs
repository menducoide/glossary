using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Glossary.Test.Fixtures
{
    public abstract class IntegrationTest : IClassFixture<GlossaryAPIFactory>
    {
        protected readonly GlossaryAPIFactory _factory;
        protected readonly HttpClient _client;

        public IntegrationTest(GlossaryAPIFactory fixture)
        {
            try
            {
                _factory = fixture;
                _client = _factory.CreateClient();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}

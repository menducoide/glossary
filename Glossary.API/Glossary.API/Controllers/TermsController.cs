using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Glossary.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TermsController : ControllerBase
    {
        private readonly ILogger<TermsController> _logger;

        public TermsController(ILogger<TermsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}

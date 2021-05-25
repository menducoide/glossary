using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Glossary.Domain.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Glossary.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TermsController : ControllerBase
    {
        private readonly ILogger<TermsController> _logger;
        private readonly ITermService _termService;

        public TermsController(ILogger<TermsController> logger, ITermService termService)
        {
            _logger = logger;
            _termService = termService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _termService.List());
        }
    }
}

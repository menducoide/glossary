using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Glossary.DataTransferObjects.Models;
using Glossary.Domain.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Glossary.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            return Ok(await _termService.GetBy(id));
        }
        [HttpGet("{name}/{id}")]
        public async Task<IActionResult> ListBy(string name, int id = 0)
        {
            return Ok(await _termService.ListBy(name, id));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TermDto dto)
        {
            try
            {
                if ((await _termService.ListBy(dto.Name)).Any())
                {
                    return BadRequest("Term should be unique");
                }
                return Ok(await _termService.Insert(dto));
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] TermDto dto)
        {
            try
            {
                if ((await _termService.ListBy(dto.Name,id)).Any())
                {
                    return BadRequest("Term should be unique");
                }
                await _termService.Update(id, dto);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}

using DWFIAP.Application.DTOs.Turma;
using DWFIAP.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DWFIAP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService alunoService)
        {
            _turmaService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _turmaService.GetAllAsync();

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _turmaService.GetByIdAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateTurmaDTO aluno)
        {
            var result = await _turmaService.CreateAsync(aluno);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] TurmaDTO aluno)
        {
            var result = await _turmaService.EditAsync(aluno);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _turmaService.DeleteAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

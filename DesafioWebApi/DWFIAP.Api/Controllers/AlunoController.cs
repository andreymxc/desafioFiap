using DWFIAP.Application.DTOs.Aluno;
using DWFIAP.Application.Services.Interfaces;
using DWFIAP.BusinessLogic.DTOs.Aluno;
using Microsoft.AspNetCore.Mvc;

namespace DWFIAP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _alunoService.GetAllAsync();

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _alunoService.GetByIdAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateAlunoDTO aluno)
        {
            var result = await _alunoService.CreateAsync(aluno);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] AlunoDTO aluno)
        {
            var result = await _alunoService.EditAsync(aluno);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _alunoService.DeleteAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

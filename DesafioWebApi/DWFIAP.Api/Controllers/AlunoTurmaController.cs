using DWFIAP.Application.DTOs.AlunoTurma;
using DWFIAP.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DWFIAP.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AlunoTurmaController : ControllerBase
    {
        private readonly IAlunoTurmaService _alunoTurmaService;

        public AlunoTurmaController(IAlunoTurmaService alunoService)
        {
            _alunoTurmaService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _alunoTurmaService.GetAllAsync();

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [Route("Aluno/{idAluno}/Turma/{idTurma}")]
        [HttpGet]
        public async Task<ActionResult> GetById(int idAluno, int idTurma)
        {
            var result = await _alunoTurmaService.GetByIdAsync(idAluno, idTurma);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AlunoTurmaDTO alunoTurmaDto)
        {
            var result = await _alunoTurmaService.CreateAsync(alunoTurmaDto);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [Route("Aluno/{idAluno}/Turma/{idTurma}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int idAluno,int idTurma)
        {
            var result = await _alunoTurmaService.DeleteAsync(idAluno, idTurma);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

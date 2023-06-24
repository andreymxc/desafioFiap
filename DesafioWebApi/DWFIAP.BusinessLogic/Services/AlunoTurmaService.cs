using AutoMapper;
using DWFIAP.Application.DTOs.AlunoTurma;
using DWFIAP.Application.Services.Interfaces;
using DWFIAP.Domain.Repositories;
using DWFIAP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Application.Services
{
    public class AlunoTurmaService : IAlunoTurmaService
    {

        private readonly IAlunoTurmaRepository _alunoTurmaRepository;
        private readonly IMapper _mapper;

        public AlunoTurmaService(IAlunoTurmaRepository alunoTurmaRepository, IMapper mapper)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<AlunoTurmaDTO>> CreateAsync(AlunoTurmaDTO alunoTurmaDto)
        {
            if (alunoTurmaDto == null)
                return ResultService.Fail<AlunoTurmaDTO>("Objeto deve ser informado.");

            if (await _alunoTurmaRepository.CheckIfExists(alunoTurmaDto.Aluno_Id, alunoTurmaDto.Turma_Id))
                return ResultService.Fail<AlunoTurmaDTO>("Relação de Aluno e Turma já existe!");

            var alunoTurma = _mapper.Map<Aluno_Turma>(alunoTurmaDto);

            var data = await _alunoTurmaRepository.CreateAsync(alunoTurma);

            return ResultService.Ok<AlunoTurmaDTO>(_mapper.Map<AlunoTurmaDTO>(alunoTurma));
        }

        public async Task<ResultService> DeleteAsync(int idAluno, int idTurma)
        {
            if (idAluno <= 0)
                return ResultService.Fail("Id aluno é inválido");

            if (idTurma <= 0)
                return ResultService.Fail("Id turma é inválido");

            if (await _alunoTurmaRepository.CheckIfExists(idAluno, idTurma) == false)
                return ResultService.Fail<AlunoTurmaDTO>("Relação Aluno e Turma informado não existe.");

            await _alunoTurmaRepository.DeleteAsync(idAluno, idTurma);

            return ResultService.Ok("Aluno excluido com sucesso");
        }

        public Task<ResultService<AlunoTurmaDTO>> EditAsync(AlunoTurmaDTO aluno)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultService<ICollection<AlunoTurmaDTO>>> GetAllAsync()
        {
            var alunosTurmas = await _alunoTurmaRepository.GetAlunosTurmasAsync();

            var mappedAT = _mapper.Map<ICollection<AlunoTurmaDTO>>(alunosTurmas);

            return ResultService.Ok<ICollection<AlunoTurmaDTO>>(mappedAT);
        }

     
        public async Task<ResultService<AlunoTurmaDTO>> GetByIdAsync(int idAluno, int idTurma)
        {
            var alunoTurma = await _alunoTurmaRepository.GetByIdAsync(idAluno,idTurma);

            if (alunoTurma == null)
                return ResultService.Fail<AlunoTurmaDTO>("Aluno Turma não encontrado");

            var mappedAluno = _mapper.Map<AlunoTurmaDTO>(alunoTurma);

            return ResultService.Ok(mappedAluno);
        }
    }
}

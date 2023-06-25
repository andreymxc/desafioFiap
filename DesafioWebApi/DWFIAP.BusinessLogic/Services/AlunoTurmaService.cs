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
        public async Task<ResultService<CreateAlunoTurmaDTO>> CreateAsync(CreateAlunoTurmaDTO alunoTurmaDto)
        {
            if (alunoTurmaDto == null)
                return ResultService.Fail<CreateAlunoTurmaDTO>("Objeto deve ser informado.");

            if (await _alunoTurmaRepository.CheckIfExists(alunoTurmaDto.Aluno_Id, alunoTurmaDto.Turma_Id))
                return ResultService.Fail<CreateAlunoTurmaDTO>("Relação de Aluno e Turma já existe!");

            var alunoTurma = _mapper.Map<Aluno_Turma>(alunoTurmaDto);

            var data = await _alunoTurmaRepository.CreateAsync(alunoTurma);

            return ResultService.Ok<CreateAlunoTurmaDTO>(_mapper.Map<CreateAlunoTurmaDTO>(alunoTurma));
        }

        public async Task<ResultService> DeleteAsync(int idAluno, int idTurma)
        {
            if (idAluno <= 0)
                return ResultService.Fail("Id aluno é inválido");

            if (idTurma <= 0)
                return ResultService.Fail("Id turma é inválido");

            if (await _alunoTurmaRepository.CheckIfExists(idAluno, idTurma) == false)
                return ResultService.Fail<CreateAlunoTurmaDTO>("Relação Aluno e Turma informado não existe.");

            await _alunoTurmaRepository.DeleteAsync(idAluno, idTurma);

            return ResultService.Ok("Aluno excluido com sucesso");
        }

        public Task<ResultService<CreateAlunoTurmaDTO>> EditAsync(CreateAlunoTurmaDTO aluno)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultService<ICollection<CreateAlunoTurmaDTO>>> GetAllAsync()
        {
            var alunosTurmas = await _alunoTurmaRepository.GetAlunosTurmasAsync();

            var mappedAT = _mapper.Map<ICollection<CreateAlunoTurmaDTO>>(alunosTurmas);

            return ResultService.Ok<ICollection<CreateAlunoTurmaDTO>>(mappedAT);
        }

     
        public async Task<ResultService<CreateAlunoTurmaDTO>> GetByIdAsync(int idAluno, int idTurma)
        {
            var alunoTurma = await _alunoTurmaRepository.GetByIdAsync(idAluno,idTurma);

            if (alunoTurma == null)
                return ResultService.Fail<CreateAlunoTurmaDTO>("Aluno Turma não encontrado");

            var mappedAluno = _mapper.Map<CreateAlunoTurmaDTO>(alunoTurma);

            return ResultService.Ok(mappedAluno);
        }
    }
}

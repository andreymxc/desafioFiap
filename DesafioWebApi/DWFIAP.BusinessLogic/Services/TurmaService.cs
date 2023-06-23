using AutoMapper;
using DWFIAP.Application.DTOs.Turma;
using DWFIAP.Application.DTOs.Validations;
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
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMapper _mapper;

        public TurmaService(ITurmaRepository alunoRepository, IMapper mapper)
        {
            _turmaRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<TurmaDTO>> CreateAsync(CreateTurmaDTO turmaDTO)
        {
            if (turmaDTO == null)
                return ResultService.Fail<TurmaDTO>("Objeto deve ser informado.");

            var result = new TurmaDTOValidator().Validate(turmaDTO);

            if (result.IsValid == false)
                return ResultService.RequestError<TurmaDTO>("Problemas de validação.", result);

            var turma = _mapper.Map<Turma>(turmaDTO);

            var data = await _turmaRepository.CreateAsync(turma);
            return ResultService.Ok<TurmaDTO>(_mapper.Map<TurmaDTO>(turma));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            if (id <= 0)
                return ResultService.Fail("Id informado é inválido");

            if (await _turmaRepository.CheckIfExists(id) == false)
                return ResultService.Fail<TurmaDTO>("Turma informada não existe.");

            await _turmaRepository.DeleteAsync(id);

            return ResultService.Ok("Turma excluida com sucesso");
        }

        public async Task<ResultService<TurmaDTO>> EditAsync(TurmaDTO turmaDTO)
        {
            if (turmaDTO == null)
                return ResultService.Fail<TurmaDTO>("Objeto deve ser informado.");

            if (await _turmaRepository.CheckIfExists(turmaDTO.Id) == false)
                return ResultService.Fail<TurmaDTO>("Turma informado não existe.");

            var mappedTurma = _mapper.Map<Turma>(turmaDTO);

            var data = await _turmaRepository.EditAsync(mappedTurma);
            return ResultService.Ok<TurmaDTO>(_mapper.Map<TurmaDTO>(mappedTurma));
        }

        public async Task<ResultService<ICollection<TurmaDTO>>> GetAllAsync()
        {
            var alunos = await _turmaRepository.GetAllAsync();

            var mappedAlunos = _mapper.Map<ICollection<TurmaDTO>>(alunos);

            return ResultService.Ok<ICollection<TurmaDTO>>(mappedAlunos);
        }

        public async Task<ResultService<TurmaDTO>> GetByIdAsync(int id)
        {
            var aluno = await _turmaRepository.GetByIdAsync(id);

            if (aluno == null)
                return ResultService.Fail<TurmaDTO>("Turma não encontrado");

            var mappedAluno = _mapper.Map<TurmaDTO>(aluno);

            return ResultService.Ok(mappedAluno);
        }
    }
}

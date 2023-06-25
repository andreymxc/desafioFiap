using AutoMapper;
using DWFIAP.Application.DTOs.Aluno;
using DWFIAP.Application.DTOs.Validations;
using DWFIAP.Application.Services.Interfaces;
using DWFIAP.BusinessLogic.DTOs.Aluno;
using DWFIAP.Domain.Repositories;
using DWFIAP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoService(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<AlunoDTO>> CreateAsync(CreateAlunoDTO alunoDTO)
        {
            if (alunoDTO == null)
                return ResultService.Fail<AlunoDTO>("Objeto deve ser informado.");

            if (await _alunoRepository.CheckUserName(alunoDTO.Usuario))
                return ResultService.Fail<AlunoDTO>("Nome da usuário já existe.");

            var result = new AlunoDTOValidator().Validate(alunoDTO);

            if (result.IsValid == false)
                return ResultService.RequestError<AlunoDTO>("Problemas de validação.", result);

            var aluno = _mapper.Map<Aluno>(alunoDTO);
            aluno.Senha = Tools.SecretHasher.GetHashString(aluno.Senha);

            var data = await _alunoRepository.CreateAsync(aluno);

            return ResultService.Ok<AlunoDTO>(_mapper.Map<AlunoDTO>(aluno));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            if(id <= 0)
                return ResultService.Fail("Id informado é inválido");

            if (await _alunoRepository.CheckIfExists(id) == false)
                return ResultService.Fail<AlunoDTO>("Aluno informado não existe.");

            await _alunoRepository.DeleteAsync(id);

            return ResultService.Ok("Aluno excluido com sucesso");
        }

        public async Task<ResultService<AlunoDTO>> EditAsync(AlunoDTO alunoDTO)
        {
            if (alunoDTO == null)
                return ResultService.Fail<AlunoDTO>("Objeto deve ser informado.");

            if(await _alunoRepository.CheckIfExists(alunoDTO.Id) == false)
                return ResultService.Fail<AlunoDTO>("Aluno informado não existe.");

            var mappedAluno = _mapper.Map<Aluno>(alunoDTO);

            mappedAluno.Senha = Tools.SecretHasher.GetHashString(mappedAluno.Senha);

            var data = await _alunoRepository.EditAsync(mappedAluno);               
            return ResultService.Ok<AlunoDTO>(_mapper.Map<AlunoDTO>(mappedAluno));
        }

        public async Task<ResultService<ICollection<AlunoDTO>>> GetAllAsync()
        {
            var alunos = await _alunoRepository.GetAlunosAsync();

            var mappedAlunos = _mapper.Map<ICollection<AlunoDTO>>(alunos);

            return ResultService.Ok<ICollection<AlunoDTO>>(mappedAlunos);           
        }

        public async Task<ResultService<AlunoDTO>> GetByIdAsync(int id)
        {
            var aluno = await _alunoRepository.GetByIdAsync(id);

            if (aluno == null)
                return ResultService.Fail<AlunoDTO>("Aluno não encontrado");

            var mappedAluno = _mapper.Map<AlunoDTO>(aluno);

            return ResultService.Ok(mappedAluno);
        }     
    }
}

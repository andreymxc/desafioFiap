using AutoMapper;
using DWFIAP.Application.DTOs.Aluno;
using DWFIAP.Application.DTOs.AlunoTurma;
using DWFIAP.Application.DTOs.Turma;
using DWFIAP.BusinessLogic.DTOs.Aluno;
using DWFIAP.Model.Entities;

namespace DWFIAP.Application.Mappings
{
    public class DTOToDomainMapping : Profile
    {
        public DTOToDomainMapping()
        {
            CreateMap<CreateAlunoDTO, Aluno>();
            CreateMap<AlunoDTO, Aluno>();
            CreateMap<AlunoDTO, CreateAlunoDTO>();

            CreateMap<CreateTurmaDTO, Turma>();
            CreateMap<TurmaDTO, Turma>();
            CreateMap<TurmaDTO, CreateTurmaDTO>();

            CreateMap<AlunoTurmaDTO, Aluno_Turma>();
        }
    }
}

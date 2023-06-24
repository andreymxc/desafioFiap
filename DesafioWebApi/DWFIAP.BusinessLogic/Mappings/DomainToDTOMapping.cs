using AutoMapper;
using DWFIAP.Application.DTOs.Aluno;
using DWFIAP.Application.DTOs.AlunoTurma;
using DWFIAP.Application.DTOs.Turma;
using DWFIAP.BusinessLogic.DTOs.Aluno;
using DWFIAP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Application.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping()
        {
            CreateMap<Aluno, CreateAlunoDTO>();
            CreateMap<Aluno, AlunoDTO>();

            CreateMap<Turma, TurmaDTO>();
            CreateMap<Turma, CreateTurmaDTO>();

            CreateMap<Aluno_Turma, AlunoTurmaDTO>()
            .ForMember(dest => dest.Turma, opt => opt.MapFrom(i => i.Turma))
            .ForMember(dest => dest.Aluno, opt => opt.MapFrom(i => i.Aluno));
        }
    }
}

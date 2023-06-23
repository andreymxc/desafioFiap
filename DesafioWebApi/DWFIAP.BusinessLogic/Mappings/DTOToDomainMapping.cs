using AutoMapper;
using DWFIAP.Application.DTOs.Aluno;
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
        }
    }
}

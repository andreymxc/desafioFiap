using DWFIAP.Application.DTOs.Turma;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Application.DTOs.Validations
{
    public class TurmaDTOValidator : AbstractValidator<CreateTurmaDTO>
    {
        public TurmaDTOValidator()
        {
            RuleFor(i => i.Ano)
                .NotNull()
                .Must(j => j >= DateTime.Now.Year)
                .WithMessage("Ano da turma é inválido. Deve ser maior ou igual ao ano atual.");
                
            RuleFor(i => i.Nome)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome da turma deve ser informada.")
                .MaximumLength(45).WithMessage("Nome da turma deve ter no máximo 45 caracteres.");


            RuleFor(i => i.Curso_Id)
               .NotEmpty()
               .NotNull()
               .WithMessage("Identificador do curso inválido.");
        }
    }
}

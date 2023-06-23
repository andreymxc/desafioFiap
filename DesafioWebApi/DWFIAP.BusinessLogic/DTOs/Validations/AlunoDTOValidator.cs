using DWFIAP.BusinessLogic.DTOs.Aluno;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Application.DTOs.Validations
{
    public class AlunoDTOValidator : AbstractValidator<CreateAlunoDTO>
    {
        public AlunoDTOValidator()
        {
            RuleFor(i => i.Usuario)
                .NotEmpty()
                .NotNull()
                .WithMessage("Usuário deve ser informado.");

            RuleFor(i => i.Nome)
               .NotEmpty()
               .NotNull()
               .WithMessage("Nome deve ser informado.");

            RuleFor(i => i.Senha)
               .NotEmpty()
               .NotNull()
               .WithMessage("Senha deve ser informada.");

        }
    }
}

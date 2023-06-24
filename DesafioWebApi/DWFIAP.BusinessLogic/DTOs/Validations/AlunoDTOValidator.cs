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
                .WithMessage("Usuário deve ser informado.")
                .MaximumLength(45).WithMessage("O Usuario não deve ter mais que 45 caracteres");
                
            RuleFor(i => i.Nome)
               .NotEmpty()
               .NotNull()
               .WithMessage("Nome deve ser informado.")
               .MaximumLength(255).WithMessage("O nome não deve ter mais que 255 caracteres");

            RuleFor(p => p.Senha).NotEmpty().WithMessage("A senha não pode ser vazia")
                  .MinimumLength(8).WithMessage("A senha deve conter pelo menos 8 caracteres")
                  .MaximumLength(16).WithMessage("A senha não deve conter mais que 16 caracteres")
                  .Matches(@"[A-Z]+").WithMessage("A senha deve conter pelo menos uma letra maiúscula")
                  .Matches(@"[a-z]+").WithMessage("A senha deve conter pelo menos uma letra minúscula")
                  .Matches(@"[0-9]+").WithMessage("A senha deve conter pelo menos um número.")
                  .Matches(@"(?=.*\W)").WithMessage("A senha deve conter pelo menos 1 caractere especial.");
        }
    }
}

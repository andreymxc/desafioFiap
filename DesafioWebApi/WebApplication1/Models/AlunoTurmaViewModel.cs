using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DWFIAP.WebApp.Models
{
    public class AlunoTurmaViewModel
    {
        public int Aluno_Id { get; set; }
        public int Turma_Id { get; set; }

        public IEnumerable<SelectListItem> Alunos { get; set; }
        public IEnumerable<SelectListItem> Turmas { get; set; }

    }
}

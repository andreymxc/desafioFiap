using DWFIAP.Application.DTOs.Turma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Application.DTOs.AlunoTurma
{
    public class AlunoTurmaAlunoDTO
    {
        public int Id_Aluno { get; set; }
        public string NomeAluno { get; set; }
        public List<TurmaDTO> Turmas { get; set; }
    }
}

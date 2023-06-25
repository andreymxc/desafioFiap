using DWFIAP.Application.DTOs.Aluno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Application.DTOs.Turma
{
    public class TurmaDTO
    {
        public int Id { get; set; }
        public int Curso_Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public List<AlunoDTO> Alunos { get; set; }

        public TurmaDTO()
        {
            Alunos = new List<AlunoDTO>();
        }
    }
}

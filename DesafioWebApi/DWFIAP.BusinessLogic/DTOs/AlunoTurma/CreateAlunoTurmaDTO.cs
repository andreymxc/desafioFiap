using DWFIAP.Application.DTOs.Aluno;
using DWFIAP.Application.DTOs.Turma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Application.DTOs.AlunoTurma
{
    public class CreateAlunoTurmaDTO
    {
        public int Aluno_Id { get; set; }
        public int Turma_Id { get; set; }
      
        public CreateAlunoTurmaDTO()
        {

        }
    }
}

using DWFIAP.Application.DTOs.Turma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Application.DTOs.Aluno
{
    public class AlunoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public List<TurmaDTO> Turmas { get; set; }

        public bool Ativo { get; set; }

        public AlunoDTO()
        {
            Turmas = new List<TurmaDTO>();
        } 
    }
}

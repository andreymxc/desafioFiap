using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Model.Entities
{
    public class Turma
    {
        public int Id { get; set; }
        public int Curso_Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public bool Ativo { get; set; }

        public List<Aluno> Alunos { get; set; } = new List<Aluno>();

        public Turma()
        {

        }
    }
}

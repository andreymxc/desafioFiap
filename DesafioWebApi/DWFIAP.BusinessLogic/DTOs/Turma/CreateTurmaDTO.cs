using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Application.DTOs.Turma
{
    public class CreateTurmaDTO
    {
        public int Curso_Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
    }
}

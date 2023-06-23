using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.BusinessLogic.DTOs.Aluno
{
    public class CreateAlunoDTO
    {
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public CreateAlunoDTO()
        {

        }
    }
}

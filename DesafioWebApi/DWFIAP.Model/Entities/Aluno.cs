using DWFIAP.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Model.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public List<Turma> Turmas { get; set; } = new List<Turma>();

        public Aluno()
        {

        }

        public Aluno(int id, string nome, string usuario, string senha)
        {
            DomainValidationException.When(id <= 0, "Id deve ser maior que zero.");
            Id = id;
            Validation(nome, usuario, senha);
        }
        private void Validation(string nome, string usuario, string senha)
        {
            DomainValidationException.When(string.IsNullOrEmpty(nome), "Nome deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(usuario), "Usuario deve ser informado.");
            DomainValidationException.When(string.IsNullOrEmpty(senha), "Senha deve ser informada.");

            Nome = nome;
            Usuario = usuario;
            Senha = senha.Trim();
            Turmas = new List<Turma>();
        }
    }
}

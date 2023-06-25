namespace DWFIAP.WebApp.Models
{
    public class TurmaDetailsViewModel
    {
        public int Id { get; set; }
        public int Curso_Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }

        public List<AlunoViewModel> Alunos { get; set; }
    }
}

namespace DWFIAP.WebApp.Models
{
    public class AlunoDetailsViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public List<TurmaViewModel> Turmas { get; set; }
    }
}

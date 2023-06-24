using DWFIAP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Domain.Repositories
{
    public interface IAlunoTurmaRepository
    {
        public Task<Aluno_Turma> CreateAsync(Aluno_Turma aluno);
        public Task DeleteAsync(int idAluno, int idTurma);
        public Task<Aluno_Turma> EditAsync(Aluno_Turma aluno);
        public Task<ICollection<Aluno_Turma>> GetAlunosTurmasAsync();
        public Task<Aluno_Turma> GetByIdAsync(int idAluno, int idTurma);
        public Task<bool> CheckIfExists(int idAluno, int idTurma);
    }
}

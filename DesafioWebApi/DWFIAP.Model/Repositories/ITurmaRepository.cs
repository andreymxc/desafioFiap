using DWFIAP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Domain.Repositories
{
    public interface ITurmaRepository
    {
        Task<Turma> CreateAsync(Turma turma);
        Task<ICollection<Turma>> GetAllAsync();
        Task<Turma> GetByIdAsync(int id);
        Task<Turma> EditAsync(Turma turma);
        Task DeleteAsync(int id);
        Task<bool> CheckIfExists(int id);
        Task<bool> CheckName(string username);

    }
}

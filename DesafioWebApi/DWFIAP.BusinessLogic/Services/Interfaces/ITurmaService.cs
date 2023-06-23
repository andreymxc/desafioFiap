using DWFIAP.Application.DTOs.Turma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Application.Services.Interfaces
{
    public interface ITurmaService
    {
        Task<ResultService<TurmaDTO>> CreateAsync(CreateTurmaDTO aluno);
        Task<ResultService<TurmaDTO>> GetByIdAsync(int id);
        Task<ResultService<TurmaDTO>> EditAsync(TurmaDTO aluno);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<ICollection<TurmaDTO>>> GetAllAsync();
    }
}

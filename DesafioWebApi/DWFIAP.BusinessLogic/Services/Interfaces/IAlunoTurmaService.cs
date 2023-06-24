using DWFIAP.Application.DTOs.AlunoTurma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Application.Services.Interfaces
{
    public interface IAlunoTurmaService
    {
        Task<ResultService<AlunoTurmaDTO>> CreateAsync(AlunoTurmaDTO aluno);
        Task<ResultService<AlunoTurmaDTO>> GetByIdAsync(int idAluno, int idTurma);
        Task<ResultService<AlunoTurmaDTO>> EditAsync(AlunoTurmaDTO aluno);
        Task<ResultService> DeleteAsync(int idAluno, int idTurma);
        Task<ResultService<ICollection<AlunoTurmaDTO>>> GetAllAsync();
    }
}

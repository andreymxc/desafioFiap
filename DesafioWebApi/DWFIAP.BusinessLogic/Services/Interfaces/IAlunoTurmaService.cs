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
        Task<ResultService<CreateAlunoTurmaDTO>> CreateAsync(CreateAlunoTurmaDTO aluno);
        Task<ResultService<CreateAlunoTurmaDTO>> GetByIdAsync(int idAluno, int idTurma);
        Task<ResultService<CreateAlunoTurmaDTO>> EditAsync(CreateAlunoTurmaDTO aluno);
        Task<ResultService> DeleteAsync(int idAluno, int idTurma);
        Task<ResultService<ICollection<CreateAlunoTurmaDTO>>> GetAllAsync();
    }
}

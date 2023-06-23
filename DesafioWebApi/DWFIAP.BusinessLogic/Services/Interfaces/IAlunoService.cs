using DWFIAP.Application.DTOs.Aluno;
using DWFIAP.BusinessLogic.DTOs.Aluno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Application.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<ResultService<AlunoDTO>> CreateAsync(CreateAlunoDTO aluno);
        Task<ResultService<AlunoDTO>> GetByIdAsync(int id);
        Task<ResultService<AlunoDTO>> EditAsync(AlunoDTO aluno);
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<ICollection<AlunoDTO>>> GetAllAsync();
    }
}

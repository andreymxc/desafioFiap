using Dapper;
using DWFIAP.Data.Configuration;
using DWFIAP.Domain.Repositories;
using DWFIAP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Infra.Data.Repositories
{
    public class AlunoTurmaRepository : IAlunoTurmaRepository
    {

        private readonly DWFIAP.Data.Configuration.DwfiapContext _db;

        public AlunoTurmaRepository(DwfiapContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckIfExists(int idAluno, int idTurma)
        {
            using (var conn = _db.CreateConnection())
            {
                return conn.Query<object>(
                "SELECT 1 WHERE EXISTS (SELECT 1 FROM Aluno_Turma WHERE Aluno_Id = @idAluno AND Turma_Id = @idTurma )", new { idAluno = idAluno, idTurma = idTurma  })
                .Any();
            }
        }

        public async Task<Aluno_Turma> CreateAsync(Aluno_Turma alunoTurma)
        {
            var query = @"INSERT INTO Aluno_Turma (Aluno_Id, Turma_Id) 
                         VALUES (@AlunoId, @TurmaId);";

            var parameters = new DynamicParameters();
            parameters.Add("AlunoId", alunoTurma.Aluno_Id, System.Data.DbType.String);
            parameters.Add("TurmaId", alunoTurma.Turma_Id, System.Data.DbType.String);

            using (var conn = _db.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);
                return alunoTurma;
            }
        }

        public async Task DeleteAsync(int idAluno, int idTurma)
        {
            var query = "DELETE from Aluno_Turma WHERE Aluno_Id = @idAluno AND Turma_Id = @idTurma";

            var parameters = new DynamicParameters();
            parameters.Add("idAluno", idAluno, System.Data.DbType.Int32);
            parameters.Add("idTurma", idTurma, System.Data.DbType.Int32);

            using (var conn = _db.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);
            }
        }

        public Task<Aluno_Turma> EditAsync(Aluno_Turma aluno)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Aluno_Turma>> GetAlunosTurmasAsync()
        {
            var query = "SELECT * FROM ALUNO_TURMA";

            using (var connection = _db.CreateConnection())
            {
                var alunos = await connection.QueryAsync<Aluno_Turma>(query);
                return alunos.ToList();
            }
        }

        public async Task<Aluno_Turma> GetByIdAsync(int idAluno, int idTurma)
        {
            var query = "SELECT * FROM ALUNO_TURMA WHERE Aluno_Id = @idAluno AND Turma_Id = @idTurma";

            using (var conn = _db.CreateConnection())
            {
                var alunoTurma = await conn.QueryFirstOrDefaultAsync<Aluno_Turma>(query, new { idAluno = idAluno, idTurma = idTurma });

                return alunoTurma;
            }
        }
    }
}

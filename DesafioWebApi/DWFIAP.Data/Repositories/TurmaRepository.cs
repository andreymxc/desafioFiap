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
    public class TurmaRepository : ITurmaRepository
    {
        private readonly DWFIAP.Data.Configuration.DwfiapContext _db;

        public TurmaRepository(DwfiapContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckIfExists(int id)
        {
            using (var conn = _db.CreateConnection())
            {
                return conn.Query<object>(
                "SELECT 1 WHERE EXISTS (SELECT 1 FROM Turma WHERE ID = @id)", new { id = id })
                .Any();
            }
        }


        public async Task<Turma> CreateAsync(Turma turma)
        {
            var query = @"INSERT INTO Turma (Curso_Id, Nome, Ano) 
                         VALUES (@Curso_Id, @Nome, @Ano);" +
                                    "SELECT CAST(SCOPE_IDENTITY() AS int)";

            var parameters = new DynamicParameters();
            parameters.Add("Curso_Id", turma.Curso_Id, System.Data.DbType.String);
            parameters.Add("Nome", turma.Nome, System.Data.DbType.String);
            parameters.Add("Ano", turma.Ano, System.Data.DbType.String);

            using (var conn = _db.CreateConnection())
            {
                var id = await conn.QuerySingleAsync<int>(query, parameters);
                turma.Id = (int)id;
                return turma;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var query = "UPDATE Turma SET ATIVO = 0 WHERE ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);

            using (var conn = _db.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);
            }
        }

        public async Task<Turma> EditAsync(Turma turma)
        {
            var query = @"UPDATE Turma SET
                Curso_Id = @Curso_Id,
                Nome = @Nome,
                Ano = @Ano
                WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", turma.Id, System.Data.DbType.Int32);
            parameters.Add("Curso_Id", turma.Curso_Id, System.Data.DbType.String);
            parameters.Add("Nome", turma.Nome, System.Data.DbType.String);
            parameters.Add("Ano", turma.Ano, System.Data.DbType.String);

            using (var conn = _db.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);
                return turma;
            }
        }

        public async Task<ICollection<Turma>> GetAllAsync()
        {
            var query = "SELECT * FROM TURMA WHERE ATIVO = 1";

            using (var connection = _db.CreateConnection())
            {
                var turmas = await connection.QueryAsync<Turma>(query);
                return turmas.ToList();
            }
        }

        public async Task<Turma> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM TURMA WHERE ID = @id";

            using (var conn = _db.CreateConnection())
            {
                var turma = await conn.QueryFirstOrDefaultAsync<Turma>(query, new { Id = id });

                query = @"SELECT
                            a.Id, 
                            a.Nome, 
                            a.Usuario,
                            a.Senha,
                            a.Ativo
                            FROM Aluno AS a
                            JOIN Aluno_Turma AS tb ON ALUNO_ID = a.Id
                            WHERE tb.Turma_Id = @id;";

                var alunos = await conn.QueryAsync<Aluno>(query, new { Id = id });

                if (alunos.Any())
                    turma.Alunos = alunos.ToList();

                return turma;
            }
        }

        public async Task<bool> CheckName(string nome)
        {
            using (var conn = _db.CreateConnection())
            {
                 return conn.Query<object>(
                "SELECT 1 WHERE EXISTS (SELECT 1 FROM Turma WHERE nome = @nome)", new { nome = nome })
                .Any();
            }
        }
    }
}

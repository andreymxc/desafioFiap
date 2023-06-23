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
    public class AlunoRepository : IAlunoRepository
    {
        private readonly DWFIAP.Data.Configuration.DwfiapContext _db;

        public AlunoRepository(DwfiapContext db)
        {
            _db = db;
        }

        public async Task<Aluno> CreateAsync(Aluno aluno)
        {
            var query = @"INSERT INTO Aluno (Nome, Usuario, Senha) 
                         VALUES (@Nome, @Usuario, @Senha);" +
                         "SELECT CAST(SCOPE_IDENTITY() AS int)";

            var parameters = new DynamicParameters();
            parameters.Add("Nome", aluno.Nome, System.Data.DbType.String);
            parameters.Add("Usuario", aluno.Usuario, System.Data.DbType.String);
            parameters.Add("Senha", aluno.Senha, System.Data.DbType.String);

            using(var conn = _db.CreateConnection())
            {
                var id = await conn.QuerySingleAsync(query, parameters);
                aluno.Id = id;
                return aluno;
            }
        }
       
        public async Task DeleteAsync(int id)
        {
            var query = "DELETE from Aluno WHERE ID = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Int32);

            using (var conn = _db.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);
            }
        }

        public async Task EditAsync(Aluno aluno)
        {
            var query = @"UPDATE Aluno SET
                Nome = @Nome,
                Usuario = @Usuario,
                Senha = @Senha
                WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", aluno.Nome, System.Data.DbType.Int32);
            parameters.Add("Nome", aluno.Nome, System.Data.DbType.String);
            parameters.Add("Usuario", aluno.Usuario, System.Data.DbType.String);
            parameters.Add("Senha", aluno.Senha, System.Data.DbType.String);

            using (var conn = _db.CreateConnection())
            {
                await conn.ExecuteAsync(query, parameters);
            }
        }

        public Task<ICollection<Aluno>> GetAlunosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM ALUNO WHERE ID = @id";

            using (var conn = _db.CreateConnection())
            {
                var produto = await conn.QueryFirstOrDefaultAsync<Aluno>(query, new { Id = id});

                return produto;
            }
        }
    }
}

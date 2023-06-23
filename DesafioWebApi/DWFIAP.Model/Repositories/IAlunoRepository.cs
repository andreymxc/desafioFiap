﻿using DWFIAP.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWFIAP.Domain.Repositories
{
    public interface IAlunoRepository
    {
        public Task<Aluno> CreateAsync(Aluno aluno);
        public  Task DeleteAsync(int id);
        public Task EditAsync(Aluno aluno);
        public Task<ICollection<Aluno>> GetAlunosAsync();
        public Task<Aluno> GetByIdAsync(int id);
    }
}
CREATE DATABASE desafio_webapi_fiap;
USE desafio_webapi_fiap;

CREATE TABLE Aluno (
Id int not null IDENTITY(1,1),
Nome varchar(255),
Usuario varchar(45),
Senha char(65),
Ativo BIT NOT NULL DEFAULT 1,
CONSTRAINT fk_aluno_1_idx PRIMARY KEY (id));

CREATE TABLE Turma (
Id int not null IDENTITY(1,1),
Curso_Id varchar(255),
Nome varchar(45),
Ano INT,
Ativo BIT NOT NULL DEFAULT 1,
CONSTRAINT fk_turma_1_idx PRIMARY KEY (id));


CREATE TABLE Aluno_Turma (
Aluno_Id int not null,
Turma_Id int not null,
CONSTRAINT fk_aluno_turma_1_idx PRIMARY KEY (Aluno_Id, Turma_Id),
CONSTRAINT fk_aluno_turma_aluno_1_idx FOREIGN KEY (Aluno_Id) REFERENCES Aluno (id),
CONSTRAINT fk_aluno_turma_turma_1_idx FOREIGN KEY (Turma_Id) REFERENCES Turma (id)
);

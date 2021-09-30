CREATE DATABASE SP_Medical_Group;
GO 

USE SP_Medical_Group;
GO


-- ESPECIALIDADES
CREATE TABLE Especialidades(
 idEspecialidade TINYINT PRIMARY KEY IDENTITY,
 TipoEspecialidade VARCHAR(100) UNIQUE NOT  NULL
);
GO

-- SITUACAO
CREATE TABLE Situacao (
  idSituacao TINYINT PRIMARY KEY IDENTITY,
  Descricao VARCHAR(25) NOT NULL UNIQUE
);
GO

-- CLINICAS
CREATE TABLE Clinicas (
   idClinica TINYINT PRIMARY KEY IDENTITY,
   CNPJ CHAR(18) UNIQUE NOT NULL,
   NomeClinica VARCHAR(100) NOT NULL,
   Endereco VARCHAR(150) UNIQUE NOT NULL,
   RazaoSocial VARCHAR(100) NOT NULL,
   HorarioAbre time,
   HorarioFecha time
);
GO
--- TIPOUSUARIO
CREATE TABLE TipoUsuario (
  idTipoUsuario TINYINT PRIMARY KEY IDENTITY,
  TituloTipoUsuario VARCHAR(50) UNIQUE NOT NULL
);
GO
-- USUARIO
CREATE TABLE Usuario (
	  idUsuario INT PRIMARY KEY IDENTITY,
	  idTipoUsuario TINYINT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario),
	  NomeUsuario VARCHAR(100) NOT NULL,
	  Email VARCHAR(256) UNIQUE NOT NULL,
	  Senha VARCHAR(15) NOT NULL CHECK( len(senha) >= 8)
);
GO

-- PRONTUÁRIO
CREATE TABLE Prontuario(
	idProntuario INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES Usuario(idUsuario),
	RG CHAR(10) UNIQUE NOT NULL,
	CPF CHAR(12) UNIQUE NOT NULL,
	Endereco VARCHAR (300) NOT NULL,
	DataNasc DATE NOT NULL,
	Email VARCHAR(256) UNIQUE NOT NULL,
	Telefone VARCHAR (13) UNIQUE
);
GO

-- MÉDICOS
CREATE TABLE Medicos (
	idMedico SMALLINT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES Usuario ( idUsuario),
	idClinica TINYINT FOREIGN KEY REFERENCES Clinicas(idClinica),
	idEspecialidade TINYINT FOREIGN KEY REFERENCES Especialidades(idEspecialidade),
	Crm CHAR (8) UNIQUE NOT NULL
	);
GO

--CONSULTAS
CREATE TABLE Consultas(
	idConsulta INT PRIMARY KEY IDENTITY,
	idMedico SMALLINT FOREIGN KEY REFERENCES Medicos(idMedico),
	idProntuario INT FOREIGN KEY REFERENCES Prontuario(idProntuario),
	idSituacao TINYINT FOREIGN KEY REFERENCES Situacao(idSituacao),
	DataConsulta DATETIME NOT NULL,
	Descricao VARCHAR (200)
);
Go

CREATE TABLE ImagemUsuario(
id int primary key identity,
idUsuario int not null unique foreign key references Usuario(idUsuario),
binario varbinary(max) not null,
mimetype varchar(30) not null,
NomeArquivo varchar(250) not null,
DataInclusao datetime default getdate() null
);
Go

DROP TABLE Consultas
DROP TABLE Medicos
DROP TABLE Prontuario
DROP TABLE ImagemUsuario
DROP TABLE Usuario
DROP TABLE TipoUsuario
DROP TABLE Clinicas
DROP TABLE Especialidades
DROP TABLE Situacao
/*
   PRIMARY KEY = CHAVE PRIMARIA
   FOREIGN KEY = CHAVE ESTRANGEIRA
   IDENTITY = Define que o campo será auto-incrementado e único.
   NOT NULL = Define que não pode ser nulo, ou seja, obrigatório.
   UNIQUE = Define que o valor do campo é unico, ou seja, não repete.
   DEFAULT = Define um valor padrão, caso nenhum seja informado.
   GO = Pausa a leitura e executa o bloco de código acima.
*/

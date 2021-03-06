USE SP_Medical_Group7;
GO

--TIPO USUARIO

INSERT INTO TipoUsuario (TituloTipoUsuario)
VALUES ('Administrador'),('Médico'),('Paciente');
GO

--USUARIO
INSERT INTO Usuario (idTipoUsuario, NomeUsuario, Email, Senha)
VALUES	(1,'Marcos Paulo','admin@admin.com','777444123'),
		(2,'Ricardo Lemos','ricardo.lemos@spmedicalgroup.com.br','123456789'),
		(2,'Roberto Possarle','roberto.possarle@spmedicalgroup.com.br','987654321'),
		(2,'Helena Starada','helena.souza@spmedicalgroup.com.br','123789456'),
		(3,'Ligia','ligia@gmail.com','789456123'),
		(3,'Alexandre','alexandre@gmail.com','546123557'),
		(3,'Fernando','fernando@gmail.com','789123456'),
		(3,'Henrique','henrique@gmail.com','456789123'),
		(3,'João','joao@hotmail.com','456123894'),
		(3,'Bruno','bruno@gmail.com','123789456'),
		(3,'Mariana','mariana@outlook.com','456123789');
GO


--comando para zera os IDs da tabela.
--TRUNCATE TABLE Usuario

-- CLINICA
INSERT INTO Clinicas (NomeClinica,RazaoSocial,Endereco,CNPJ, HorarioAbre,HorarioFecha)
VALUES ('Clinica Possarle', 'SP Medical Group','Av. Barão Limeira, 532, São Paulo, SP', '86.400.902/0001-30','07:00:00','23:00:00');
GO

-- TIPO ESPECIALIDADES
INSERT INTO Especialidades(TipoEspecialidade)
VALUES	('Acupuntura'),
		('Anestesiologia'),
		('Angiologia'),
		('Cardiologia'),
		('Cirurgia Cardiovascular'),
		('Cirurgia da Mão'),
		('Cirurgia do Aparelho Digestivo'),
		('Cirurgia Geral'),
		('Cirurgia Pediátrica'),
		('Cirurgia Plástica'),
		('Cirurgia Torácica'),
		('Cirurgia Vascular'),
		('Dermatologia'),
		('Radioterapia'),
		('Urologia'),
		('Pediatria'),
		('Psiquiatria');
GO

-- MEDICOS
INSERT INTO Medicos(idUsuario,idClinica,idEspecialidade,Crm)
VALUES	(2,1,2,'54356-SP'),
		(3,1,17,'53452-SP'),
		(4,1,16,'65463-SP');
GO




--PRONTURIO
INSERT INTO Prontuario (idUsuario,RG,CPF,Endereco,DataNasc,Email,Telefone)
VALUES	(4,'43522543-5','948398590-00','Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000','13/10/1983','ligia@gmail.com','11 93456-7654'),
		(5,'32654345-7','735569440-57','Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200','23/07/2001','alexandre@gmail.com','11 98765-6543'),
		(6,'54636525-3','168393380-02','Av. Ibirapuera - Indianópolis, 2927, São Paulo - SP, 04029-200','10/10/1978','fernando@gmail.com','11 97208-4453'),
		(7,'54366362-5','143326547-65','R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030','13/10/1985','henrique@gmail.com','11 93456-6543'),
		(8,'53254444-1','913053480-10','R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380','27/08/1975','joao@hotmail.com','11 97656-6377'),
		(9,'54566266-7','797992990-04','Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001','21/03/1972','bruno@gmail.com','11 95436-8769'),
		(10,'54566266-8','137719130-39','R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140','05/03/2018','mariana@outlook.com', null);
GO
--SITUACAO
INSERT INTO Situacao (Descricao) 
VALUES ('Realizada'),('Cancelada'),('Agendada');
GO


--CONSULTA
INSERT INTO Consultas(DataConsulta,idProntuario,idMedico,idSituacao,Descricao)
VALUES	('20/01/2020 15:00',7,3,1,'Gripe'),
		('06/01/2020 10:00',2,2,2,null),
		('07/02/2020 11:00',3,2,1,'Sintomas depressivos'),
		('06/02/2018 10:00',2,2,1,'Problemas para dormir'),
		('07/02/2021 11:00',4,1,3,null),
		('07/02/2021 11:00',7,3,2,null),
		('09/03/2021 11:00',4,1,3,null);
GO


--Comando para retirar as linhas da tabela,CUIDADO se nao colocar o WHERE
--vai retirar TODAS as linhas.
--DELETE FROM Consultas



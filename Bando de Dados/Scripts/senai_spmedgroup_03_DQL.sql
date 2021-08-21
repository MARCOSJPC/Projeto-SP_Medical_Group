USE SP_Medical_Group;
GO

Select* From Consultas
Select* From Medicos
Select* From Prontuario
Select* From Usuario
Select* From TipoUsuario
Select* From Clinicas
Select* From Especialidades
Select* From Situacao


SELECT DataConsulta,NomeUsuario as NomePaciente,Consultas.idMedico, Situacao.Descricao as Situção,Consultas.Descricao FROM Consultas
INNER JOIN Prontuario
ON Prontuario.idProntuario = Consultas.idProntuario
LEFT JOIN Usuario
ON Usuario.idUsuario = Prontuario.idUsuario
inner join Medicos
ON Medicos.idMedico = Consultas.idMedico
Inner Join Situacao
ON Situacao.idSituacao = Consultas.idSituacao



--Mostrar a quantidade de usuarios cadastrados
SELECT COUNT(idUsuario) FROM Usuario

--Converter a data de nascimento do usuario para o formato (mm-dd-yyyy)
SELECT NomeUsuario,CONVERT(CHAR, DataNasc, 103) as DataNasc FROM Prontuario
LEFT JOIN Usuario
ON Prontuario.idUsuario = Usuario.idUsuario

--Calcular a idade do usuario a partir da data de nascimento
SELECT NomeUsuario, DATEDIFF(year,DataNasc,getdate()) as Idade FROM Prontuario
LEFT JOIN Usuario
ON Prontuario.idUsuario = Usuario.idUsuario

--Retornar a quantidade de médicos de uma determinada especialidade
SELECT COUNT(idMedico) AS QuantMedicos FROM Medicos WHERE idEspecialidade = 17
SELECT COUNT(idMedico) AS QuantMedicos FROM Medicos WHERE idEspecialidade = 16


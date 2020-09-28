 
 create table Evento
    (
		Id int  PRIMARY KEY IDENTITY (1, 1),
      Local varchar(200), 
      DataEvento DATETIME, 
      Tema varchar(200),
		QtdPessoas int,
      Lote varchar(200),
      ImagemURL varchar(200),
      Telefone varchar(20),
      Email varchar(100)

    )


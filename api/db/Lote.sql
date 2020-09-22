CREATE TABLE Lote 
(
    Id INT PRIMARY KEY IDENTITY (1, 1),
    Nome VARCHAR(200),
    Preco DECIMAL(12,2),
    DataInicio DATETIME,
    DataFim DATETIME,
    Quantidade INT,
    EventoId INT FOREIGN KEY REFERENCES Eventos(Id)
)
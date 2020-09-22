CREATE TABLE PalestranteEvento
(
    PalestranteId INT FOREIGN KEY REFERENCES Palestrante(Id),
    EventoId INT FOREIGN KEY REFERENCES Eventos(Id)
)
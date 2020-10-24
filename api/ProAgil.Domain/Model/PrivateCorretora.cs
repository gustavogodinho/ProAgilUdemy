using System;

namespace ProAgil.Domain.Model
{
    public class PrivateCorretora
    {
        public int SaldoId { get; set; }
        public Controle Saldos { get; set; }
        public int MovimentoId { get; set; }
        public Controle Movimentos { get; set; }
        public int RendimentoId { get; set; }
        public Controle Rendimentos { get; set; }
        public int RentabilidadeId { get; set; }
        public Controle Rentabilidade { get; set; }
        
    }

    public class Controle
    {
        public int Id { get; set; }
        public int Qtd { get; set; }
        public string DataBase1 { get; set; }

    }



}
using System;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.Dtos
{
    public class PRV_CONTROLE
    {
        public CONTROLE Saldos { get; set; }
        public CONTROLE Movimentos { get; set; }
        public CONTROLE Rendimentos { get; set; }
        public CONTROLE Rentabilidade { get; set; }
        public CONTROLE ValoresEmTransito { get; set; }

    }

    public class CONTROLE
    {
        public int ControleId { get; set; }
        public int Qtd { get; set; }


        [Display(Name = "Data de Retorno")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage="Data em formato inválido")]
        public DateTime DataBase { get; set; }

    }

    public class ControleCountDto 
    {
        public int qtd { get; set; }
    }

}
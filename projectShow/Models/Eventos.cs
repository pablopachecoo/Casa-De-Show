using System;
using System.ComponentModel.DataAnnotations;


namespace projectShow.Models
{
    public class Eventos
    {
        [Key]
        public int EventosId {get;set;}
        public string NomeDoEvento {get;set;}
        public int CapacidadeDoevento {get;set;}
        public int QuantidadeDeIngressos {get;set;}
        [Required]
        public System.DateTime DataDoEvento {get;set;} 
        public double ValorDoIngresso {get;set;}
        public string GeneroDoEvento {get;set;}
        public int CasasDeShowId {get;set;}  
        public CasasDeShow CasasDeShow {get;set;}
    }
}
using System.ComponentModel.DataAnnotations;

namespace projectShow.Models
{
    public class Ingresso
    {
        [Key]
        public int IngressoId {get;set;}
        public int EventosId {get;set;}
        public Eventos Eventos {get;set;}
    }
}
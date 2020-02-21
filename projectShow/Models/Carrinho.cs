using System.ComponentModel.DataAnnotations;

namespace projectShow.Models
{
    public class Carrinho
    {
        [Key]
        public int CarrinhoId {get;set;}
        public int IngressoId {get;set;}
        public Ingresso Ingresso {get;set;}
        
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projectShow.Models
{
    public class CasasDeShow
    {
        [Key]
        public int CasasDeShowId {get;set;}
        public string Endereco {get;set;}
        public string NomeDaCasa {get; set;}
    }
}
using Microsoft.EntityFrameworkCore;
using projectShow.Models;
namespace projectShow.Data
{
    public class CasasDeShowContext : DbContext
    {
        public CasasDeShowContext(DbContextOptions <CasasDeShowContext> options) : base(options)
        {

        }
        public DbSet<CasasDeShow> CasasDeShow {get;set;}
    
    }
}
using Microsoft.EntityFrameworkCore;
using projectShow.Models;
namespace projectShow.Data
{
    public class EventosContext : DbContext
    {
        public EventosContext(DbContextOptions <EventosContext> evento) : base(evento)
        {

        }
        public DbSet<Eventos> Eventos {get;set;}
    }
}
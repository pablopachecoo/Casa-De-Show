using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectShow.Models;

    public class IngressoContext : DbContext
    {
        public IngressoContext (DbContextOptions<IngressoContext> options)
            : base(options)
        {
        }

        public DbSet<projectShow.Models.Ingresso> Ingresso { get; set; }
    }

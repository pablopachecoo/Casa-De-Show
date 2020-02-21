using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectShow.Models;

    public class CarrinhoContext : DbContext
    {
        public CarrinhoContext (DbContextOptions<CarrinhoContext> options)
            : base(options)
        {
        }

        public DbSet<projectShow.Models.Carrinho> Carrinho { get; set; }
    }

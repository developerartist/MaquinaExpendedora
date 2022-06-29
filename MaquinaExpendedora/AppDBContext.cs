using MaquinaExpendedora.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaquinaExpendedora
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pieza> Piezas { get; set; }
    }
}

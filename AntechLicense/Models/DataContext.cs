using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AntechLicense.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts)
        : base(opts) 
        {          
        }
        public DbSet<Licencia> Licencias { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<Category> Categories { get; set; }
        //public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraD> ComprasD { get; set; }

        // 
    }
}

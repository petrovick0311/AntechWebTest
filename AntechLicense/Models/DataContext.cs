using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AntechLicense.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        : base()
        {
        }
        public DataContext(DbContextOptions<DataContext> opts)
        : base(opts) 
        {          
        }
        
        public DbSet<E_FavouritesDrink> T_FavouritesDrinks { get; set; }
        public DbSet<E_drink> T_Drinks { get; set; }
    }
}

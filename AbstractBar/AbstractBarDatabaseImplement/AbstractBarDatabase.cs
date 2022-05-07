using AbstractBarDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace AbstractBarDatabaseImplement
{
    public class AbstractBarDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AbstractBarDatabase;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<WarehouseComponent> WarehouseComponents { get; set; }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Cocktail> Cocktails { set; get; }
        public virtual DbSet<CocktailComponent> CocktailComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }
}

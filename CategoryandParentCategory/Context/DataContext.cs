using CategoryandParentCategory.Models;
using Microsoft.EntityFrameworkCore;

namespace CategoryandParentCategory.Context
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-U1FS87R\SQLEXPRESS; database=CategoryandParentCategory; integrated security=true;");
        }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
    }
}

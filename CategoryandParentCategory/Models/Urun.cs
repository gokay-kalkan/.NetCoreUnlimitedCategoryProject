using System.ComponentModel.DataAnnotations;

namespace CategoryandParentCategory.Models
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}

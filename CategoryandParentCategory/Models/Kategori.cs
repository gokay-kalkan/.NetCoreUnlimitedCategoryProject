using System.ComponentModel.DataAnnotations;

namespace CategoryandParentCategory.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        public string Ad  { get; set; }
        public string Aciklama { get; set; }
        public int? UstKategoriId { get; set; }
        public virtual Kategori UstKategori { get; set; }

      
        public virtual List<Urun> Urunler { get; set; }
    }
}

namespace CategoryandParentCategory.Models
{
    public class AltKategorilerModel
    {
       
            public List<AltKategori> AltKategoriler { get; set; }
        

        public class AltKategori
        {
            public int Id { get; set; }
            public string Ad { get; set; }
            public string Aciklama { get; set; }
            public int? UstKategoriId { get; set; }
        }
    }
}

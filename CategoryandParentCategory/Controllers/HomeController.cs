using CategoryandParentCategory.Context;
using CategoryandParentCategory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static CategoryandParentCategory.Models.AltKategorilerModel;

namespace CategoryandParentCategory.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();

        public IActionResult Index()
        {
           
            var model = db.Kategoriler.ToList();
            return View(model);
        }

        public IActionResult Detay(int id)
        {
            var detay = db.Urunler.Include(x=>x.Kategori).Where(x => x.KategoriId == id).FirstOrDefault();
  
            return View(detay);
        }

        

     
    }
}
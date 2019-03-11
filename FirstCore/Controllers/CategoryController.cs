using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstCore.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            var db = new MyContext();

            var data = db.Categories.Include(x=>x.Products).OrderBy(x => x.CategoryName).ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var db = new MyContext();

                db.Categories.Add(new Category()
                {
                    CategoryName = model.CategoryName
                });
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                TempData["message"] = $"Bir hata oluştu: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id = 0)
        {
            var db = new MyContext();

            var category = db.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                TempData["Message"] = "Kategori bulunamadı";
                return RedirectToAction("Index");
            }

            return View(category);
        }


        [HttpPost]
        public IActionResult Edit(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var db = new MyContext();
                var data = db.Categories.FirstOrDefault(x => x.Id == model.Id);
                if (data == null)
                {
                    TempData["message"] = "Kategori bulunamadi";
                    return RedirectToAction("Index");
                }

                data.CategoryName = model.CategoryName;
                db.SaveChanges();
                TempData["message"] = "Kategori güncelleme işlemi başarılı";
            }
            catch (Exception e)
            {
                TempData["message"] = $"Bir hata oluştu: {e.Message}";
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id = 0)
        {
            var db = new MyContext();

            var cat = db.Categories.Include(x=>x.Products).FirstOrDefault(x=>x.Id == id);
            if (cat == null)
            {
                TempData["message"] = "Silinecek kategori bulunamadi";
                return RedirectToAction("Index");
            }

            if (cat.Products.Count > 0)
            {
                TempData["message"] = $"{cat.CategoryName} isimli kategoriye bağlı ürünler olduğundan silinemez";
                return RedirectToAction("Index");
            }

            db.Categories.Remove(cat);
            db.SaveChanges();
            TempData["message"] = $"{cat.CategoryName} isimli kategori başarıyla silinmiştir.";
            return RedirectToAction(nameof(Index));
        }
    }
}
using Books.Models;
using Books.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Books.Controllers
{
    public class BookController : Controller
    {
        public Context Context { get; set; }
        public BookController()
        {
            Context = new Context();
        }
        public IActionResult Index()
        {
            return View(Context.Books.Include(x=>x.Category).ToList());
        }
        public IActionResult Add()
        {
            ViewBag.categories = Context.Categories.Where(x=>x.IsActive).ToList();
            
            return View("BookForm");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAdd(Book book)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.categories = Context.Categories.Where(x => x.IsActive).ToList();
                TempData["Message"] = "Failed..!";
                return View("BookForm",book);
            }
            else
            {
                     Book _book = new Book();
                    _book.CategoryId = book.CategoryId;
                    _book.Title = book.Title;
                    _book.Description = book.Description;
                    _book.Author = book.Author;
                     Context.Books.Add(_book);
                Context.SaveChanges();
                TempData["Message"] = "Save Successfully..!";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var book = Context.Books.Include(x=>x.Category).SingleOrDefault(x=>x.Id == id);
            return View(book);
        }
        public IActionResult Edit(int id) {
            var book = Context.Books.Find(id);
            ViewBag.categories = Context.Categories.Where(x => x.IsActive).ToList();
            return View("Edit",book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEdit(int id,Book book)
        {
            if(ModelState.IsValid)
            {
                var _book = Context.Books.Find(book.Id);
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.Author = book.Author;
                _book.CategoryId = book.CategoryId;
                Context.SaveChanges();
                TempData["Message"] = "Save Successfully..!";
            }
            else
            {
                ViewBag.categories = Context.Categories.Where(x => x.IsActive).ToList();
                TempData["Message"] = "Failed..!";
                return View("Edit",book);
            }
            return RedirectToAction("index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var book = Context.Books.Find(id);
            Context.Books.Remove(book);
            Context.SaveChanges();
            
            return RedirectToAction("index");
        }

        
    }
}

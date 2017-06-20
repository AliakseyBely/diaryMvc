using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DB;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private DiaryDb context = new DiaryDb();
        public ActionResult Index()
        {
            var mess = context.MessDiaries.ToList();
            return View(mess);
        }       
        
        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View(new MessDiary());
        }
        [HttpPost]
        public ActionResult Create(MessDiary diary)
        {
            if (ModelState.IsValid)
            {
                diary.Date = DateTime.Now;
                context.MessDiaries.Add(diary);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(diary);
            }
        }

        public ActionResult Delete(int id)
        {
            MessDiary mess = context.MessDiaries
                .Where(i => i.Id == id)
                .FirstOrDefault();
            context.MessDiaries.Remove(mess);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Open()
        {
            return View();
        }  
        [HttpGet]
        public ActionResult Authorization()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Authorization()
        //{
        //    return View();
        //}
    }
}

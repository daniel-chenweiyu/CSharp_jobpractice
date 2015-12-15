using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticeWork.Models;

namespace PracticeWork.Controllers
{
    public class SchoolController : Controller
    {
        private MovieDatabase1Entities db = new MovieDatabase1Entities();
        // JOIN所有TABLE所有欄位,顯示所有狀態=Y,年紀為28~29歲的資料 
        public ActionResult Index1(string searchString)
        {
            var show = from m in db.Student select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                show = from d in db.Student where (d.Status==true && d.Age >=28 && d.Age <=29)select d;
            }
            return View(show);
        }
        public ActionResult Index2()
        {
            var show = from s in db.Student
                       join ch in db.Score on s.Id equals ch.NID
                       where ch.Subject == "中文"
                       join en in db.Score on s.Id equals en.NID
                       where ch.Subject == "英文"
                       join ma in db.Score on s.Id equals ma.NID
                       where ch.Subject == "數學"
                       where (s.Class=="A" || s.Class == "B") orderby s.Id
                       select new
                       {
                           Id = s.Id,
                           Name = s.Name,
                           Class = s.Class,
                           Chs = ch.Score1,
                           Ens = en.Score1,
                           Mas = ma.Score1,
                           Avg = (ch.Score1 + en.Score1 + ma.Score1) / 3
                       };
            //foreach(var SC in show)
            //{
            //    Console.WriteLine(SC.Id.ToString(), SC.Name, SC.Class, SC.Chs, SC.Ens, SC.Mas, SC.Avg);
            //}
            //Console.Read();
            return View(show);
        }
    }
}
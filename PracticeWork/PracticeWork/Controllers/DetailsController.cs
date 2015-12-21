using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PracticeWork.Models;
using PagedList;

namespace PracticeWork.Controllers
{
    public class DetailsController : Controller
    {
        private MovieDatabase1Entities db = new MovieDatabase1Entities();

        //設定頁面資料比數
        private int pageSize = 5;

        //從資料庫抓取電影院的值,並控制選取時的行為
        private List<SelectListItem> CategorySelectListItems(string selected = "")
        {
            var categories = from t in db.MovieTheater select t;
            var items = new List<SelectListItem>();

            var selectedCategories = string.IsNullOrWhiteSpace(selected)
                ? null
                : selected.Split(',');

            foreach (var c in categories)
            {
                items.Add(item: new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Theater,
                    Selected = selectedCategories == null
                        ? false
                        : selectedCategories.Contains(c.Id.ToString())
                });
            }
            return items;
        }

        // GET: Details
        public ActionResult Index(string movieGenre,string searchString, int page = 1)
        {
            //新增電影類型的下拉式選單
            var GenreList = new List<string>();
            //從DB搜尋電影類型的值
            var GenreQry = from d in db.MovieType orderby d.Type select d.Type;
            //宣告下拉式選單的長度
            GenreList.AddRange(GenreQry.Distinct());

            ViewBag.movieGenre = new SelectList(GenreList);

            var movies = from m in db.Detail orderby m.Id select m ;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString)).OrderBy(s=>s.Id);
            }

            if(!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre).OrderBy(s => s.Id);
            }

            int currentPage = page < 1 ? 1 : page;

            var result = movies.ToPagedList(currentPage, pageSize);

            return View(result);
        }

        // GET: Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Detail.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // GET: Details/Create
        public ActionResult Create()
        {
            //checkboxlist
            //var items = this.CategorySelectListItems();
            //ViewBag.CategoryItems = items;
            //取得所有電影類型的方法(下拉式選單)
            var GenreQry = from t in db.MovieType orderby t.Type select t;
            SelectList selectlist = new SelectList(GenreQry, "Type", "Type");
            ViewBag.movietypeselectlist = selectlist;

            return View();
        }

        // POST: Details/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ReleasDate,Genre,Price,Reservation,Theater")] Detail detail)
        //public ActionResult Create([Bind(Include = "Id,Title,ReleasDate,Genre,Price,Reservation,Theater")] Detail detail,string[] Theater)
        {
            //var detail = new Detail
            //{
            //    Theater = string.Join(",", Theater)
            //};
            if (ModelState.IsValid)
            {
                db.Detail.Add(detail);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            //var items = this.CategorySelectListItems();
            //ViewBag.CategoryItems = items;
            return View(detail);
        }

        // GET: Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Detail.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            //取得所有電影類型的方法
            var GenreQry = from t in db.MovieType orderby t.Type select t;
            var Typevalue = detail.Genre.ToString();
            //var TypeID = from d in db.MovieType where d.Type == Typevalue select d.Id;
            SelectList selectlist = new SelectList(GenreQry, "Type", "Type", Typevalue);
            ViewBag.movietypeselectlist = selectlist;
            return View(detail);
        }

        // POST: Details/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ReleasDate,Genre,Price,Reservation,Theater")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detail);
        }

        // GET: Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detail detail = db.Detail.Find(id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detail detail = db.Detail.Find(id);
            db.Detail.Remove(detail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeWork.Controllers
{
    public class UploadController : Controller
    {
   
        public ActionResult Uploadone()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Uploadone(HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/FileUploads"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("Uploadone");
        }

        public ActionResult MultiUpload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MultiUpload(IEnumerable<HttpPostedFileBase> files)
        {
            foreach(var file in files)
            {
                if (file!=null&&file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/FileUploads"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("MultiUpload");
        }
    }
}
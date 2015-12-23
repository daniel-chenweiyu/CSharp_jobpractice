using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticeWork.Models.ViewModels;
using PracticeWork.Models;


namespace PracticeWork.Controllers
{
    public class TreeViewController : Controller
    {
        private EasyUITreeHelper _helper = new EasyUITreeHelper();


        public ActionResult Index()
        {
            var rootNode = this._helper.GetRootNode();
            var nodes = this._helper.GetNodes();
            TreeViewModel model = new TreeViewModel
            {
                RootNode = rootNode,
                TreeNodes = nodes.ToList()
        };

            return View(model);
        }
    }
}
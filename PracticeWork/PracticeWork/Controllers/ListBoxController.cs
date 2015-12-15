using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using PracticeWork.Models;
using PracticeWork.Models.ViewModels;

namespace PracticeWork.Controllers
{
    public class ListBoxController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
             MovieDatabase1Entities db = new MovieDatabase1Entities();
        List<SelectListItem> listSelectListItems = new List<SelectListItem>();

            foreach (tblCity city in db.tblCity)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = city.Name,
                    Value = city.Id.ToString(),
                    Selected = city.IsSelected
                };
                listSelectListItems.Add(selectList);
            }

            CitiesViewModel citiesViewModel = new CitiesViewModel()
            {
                Cities = listSelectListItems
            };

            return View(citiesViewModel);
        }
        [HttpPost]
        public string Index(IEnumerable<string> selectedCities)
        {
            if (selectedCities == null)
            {
                return "No cities are selected";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected – " +string.Join(",", selectedCities));
                return sb.ToString();
            }
        }
    }
}
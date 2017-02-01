using PagedList;
using Shop_Product.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_Product.Viewer.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? page, string name = null)
        {
            var products = new ShopConnection().GetProducts().AsQueryable();

            if (!string.IsNullOrEmpty(name)) products = products.Where(a => a.Name != null && a.Name.ToLower().Contains(name.ToLower()));

            return View(products.OrderBy(x => x.Name).ToList().ToPagedList(page ?? 1, 20));
        }
    }
}
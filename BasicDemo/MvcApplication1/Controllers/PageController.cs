using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Business;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class PageController : Controller
    {
        //
        // GET: /Page/
        public ActionResult Index()
        {
            int currentIndex = Request["pagenow"] == null ? 1 : Convert.ToInt32(Request["pagenow"]);
            int pageSize =Request["pagesize"]==null?10: Convert.ToInt32(Request["pagesize"]);
            ViewBag.currentIndex = currentIndex;
            ViewBag.pageSize = pageSize;
            return View();
        }

        public ActionResult PageList(int pagenow = 1, int pagesize = 10)
        {
           TravelListViewModel GuideData= new TravelListBusiness().GetGuidBookList(pagenow, pagesize);
           return View(GuideData);
        }

    }
}

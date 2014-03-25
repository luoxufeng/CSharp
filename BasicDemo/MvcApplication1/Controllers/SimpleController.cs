using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainContent.Generic;
namespace MvcApplication1.Controllers
{
    public class SimpleController : Controller
    {
        //
        // GET: /Simple/

        public ActionResult ListStruct()
        {
            var intData = new PieceOfData<int>(5);
            var strData = new PieceOfData<string>("hello ,this is a list struct");
            ViewBag.IntData = string.Format("intData ={0}", intData.Data);
            ViewBag.StrData = string.Format("strData= {0}", strData.Data);
            return View();
        }

        public ActionResult ListIntface()
        {
            var sInt=new Simple<int>();
            int intData= sInt.ReturnIt(10);
            
            var str=new Simple<string>();
            var strData = str.ReturnIt("I'm Alice");
            ViewBag.Content = string.Format("intData={0},strData={1}", intData, strData);
            return View();
        }

    }
}

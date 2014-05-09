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
        #region C#基础泛型
        //
        // GET: /Simple/
        /// <summary>
        /// 泛型结构的调用
        /// </summary>
        /// <returns></returns>
        public ActionResult ListStruct()
        {
            var intData = new PieceOfData<int>(5);
            var strData = new PieceOfData<string>("hello ,this is a list struct");
            ViewBag.IntData = string.Format("intData ={0}", intData.Data);
            ViewBag.StrData = string.Format("strData= {0}", strData.Data);
            return View();
        }

        /// <summary>
        /// 泛型接口的调用
        /// </summary>
        /// <returns></returns>
        public ActionResult ListIntface()
        {
            var sInt=new Simple<int>();
            int intData= sInt.ReturnIt(10);
            
            var str=new Simple<string>();
            var strData = str.ReturnIt("I'm Alice");
            ViewBag.Content = string.Format("intData={0},strData={1}", intData, strData);
            return View();
        }
        #endregion

        #region html 
        /// <summary>
        /// form 表单get提交
        /// </summary>
        /// <param name="keyWords">此参数名称必须和form表单中提交数据的名称一致</param>
        /// <returns></returns>
        public ActionResult Search(string keyWords)
        {
            ViewBag.KeyWords = keyWords;
            return View();
        }
        #endregion

         
        [OutputCache(Duration = 300, VaryByParam = "districtId")]
        public ActionResult IsCache(long districtId = 0)
        {
            ViewBag.Number = districtId;
            return PartialView();
        }

    }
}

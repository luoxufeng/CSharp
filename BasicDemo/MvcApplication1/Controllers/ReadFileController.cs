using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DomainContent;

namespace MvcApplication1.Controllers
{
    public class ReadFileController : Controller
    {
        //
        // GET: /ReadFile/

        public ActionResult Execl()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ExeclPath"];
            DataTable dt = ReadExecl.ExcelToDataTable(path, "Sheet1");
            List<Destinat> list = GetDataTable(dt);

            return View(list);
        }

        /// <summary>
        /// 写入一个xml文件
        /// </summary>
        /// <returns></returns>
        public ActionResult GetXml()
        {
            //从Execl中读取数据
            string path = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["ExeclPath"];
            DataTable dt = ReadExecl.ExcelToDataTable(path, "Sheet1");
            List<Destinat> list = GetDataTable(dt);

            //把读取到的数据写入到xml格式的文件中
            string pathXml = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["GetXmlPath"];
            XmlHelper.XmlSerializeToFile(list,pathXml,Encoding.UTF8);

            ViewBag.IsSucceed = "顺列化成功";
            return View();
        }

        /// <summary>
        /// 读取Xml文件
        /// </summary>
        /// <returns></returns>
        public ActionResult ReadXml()
        {
            string pathXml = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["GetXmlPath"];
            var data= XmlHelper.XmlDeserializeFromFile<List<Destinat>>(pathXml, Encoding.UTF8);
            return View(data);
        }

        private List<Destinat> GetDataTable(DataTable dt)
        {
            DataTable dTable = new DataTable();
            //随机排序DataTable的方法
            List<Destinat> listDest = new List<Destinat>();
            int MAXs = 5;
            while (MAXs > 0)
            {
                int newPos = new Random(Guid.NewGuid().GetHashCode()).Next(0, dt.Rows.Count - 1);
                Destinat dtD = new Destinat()
                {
                    Name = dt.Rows[newPos][0].ToString(),
                    Url = dt.Rows[newPos][1].ToString()
                };

                if (!listDest.Exists(d => d.Name == dtD.Name))
                {
                    listDest.Add(dtD);
                    MAXs--;
                }

            }
            return listDest;
        }

    }
}

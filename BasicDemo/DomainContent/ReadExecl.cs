using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace DomainContent
{
    public class ReadExecl
    {
        /// <summary>
        /// 读取Execl文件
        /// </summary>
        /// <param name="strExcelFileName"></param>
        /// <param name="strSheetName"></param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string strExcelFileName, string strSheetName)
        {
            try
            {
                //源的定义
                // string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties='Excel 8.0;HDR=NO;IMEX=1';";
                string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties=Excel 8.0";
                //Sql语句
                //string strExcel = string.Format("select * from [{0}$]", strSheetName); 这是一种方法
                string strExcel = "select * from   [sheet1$]";

                //定义存放的数据表
                DataSet ds = new DataSet();

                //连接数据源
                OleDbConnection conn = new OleDbConnection(strConn);

                conn.Open();

                //适配到数据源
                OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
                adapter.Fill(ds, strSheetName);

                conn.Close();
                return ds.Tables[strSheetName];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取文本文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="displayCount"></param>
        /// <returns></returns>
        public List<Destinat> GetHotData(string path, int displayCount)
        {
            //获取文本中的数据源
            var resultData = new List<Destinat>();
            string[] txtData = File.ReadAllLines(@path, System.Text.Encoding.Default);
            var destDescript = (from str in txtData
                                select str.Split('\t') into temp
                                where temp.Length >= 2
                                select new Destinat() { Name = temp[0], Url = temp[1] }).ToList();


            if (displayCount >= destDescript.Count)
            {
                displayCount = destDescript.Count;
            }

            //从数据源中随机抽取几条数据
            if (destDescript != null && destDescript.Count > 0)
            {
                while (displayCount > 0)
                {
                    int randomCount = new Random(Guid.NewGuid().GetHashCode()).Next(0, destDescript.Count - 1);
                    var descript = new Destinat()
                    {
                        Name = destDescript[randomCount].Name,
                        Url = destDescript[randomCount].Url
                    };

                    if (resultData.Any(s => s.Name.Equals(descript.Name)))
                    {
                        continue;
                    }

                    resultData.Add(descript);
                    displayCount--;

                }
            }

            return resultData;
        }

    }

    public class Destinat
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}

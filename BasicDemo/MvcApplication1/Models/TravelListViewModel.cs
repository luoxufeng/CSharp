using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class TravelListViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TravelListViewModel"/> class.
        /// </summary>
        public TravelListViewModel()
        {
            this.GuidBookList = new List<GuideBook>();
        }
        /// <summary>
        /// 数据列表
        /// </summary>
        public IList<GuideBook> GuidBookList { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public long TotalCount { get; set; }


        /// <summary>
        /// 分页控件
        /// </summary>
        public NavigationViewModel NavigationBar { get; set; }
    }
}
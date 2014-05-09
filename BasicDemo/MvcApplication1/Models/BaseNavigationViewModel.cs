using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public abstract class BaseNavigationViewModel
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        protected int CurrentPageIndex { get; set; }

        /// <summary>
        /// 页面显示数量
        /// </summary>
        protected int PageSize { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        protected int TotalRecordCount { get; set; }

        /// <summary>
        /// 获取url的服务
        /// </summary>
       // protected Func<int, string> GetUriService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseNavigationViewModel"/> class.
        /// </summary>
        /// <param name="currentPageIndex">Index of the current page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalRecordCount">The total record count.</param>
        /// <param name="getUriService">get Uri Service</param>
        protected BaseNavigationViewModel(int currentPageIndex, int pageSize, int totalRecordCount, Func<int, string> getUriService = null)
        {
            this.CurrentPageIndex = currentPageIndex;
            this.PageSize = pageSize;
            this.TotalRecordCount = totalRecordCount;
           // this.GetUriService = getUriService;
        }

        /// <summary>
        /// 总页码
        /// </summary>
        protected virtual int TotalPageIndex
        {
            get
            {
                var pageIndex = 1;

                if (this.TotalRecordCount <= this.PageSize)
                {
                    return pageIndex;
                }

                var leftCount = this.TotalRecordCount - this.PageSize;
                var pagePreCount = leftCount / this.PageSize;
                var n = leftCount % this.PageSize;

                if (n == 0)
                {
                    return pagePreCount + 1;
                }

                return pagePreCount + 2;
            }
        }

        protected abstract IHtmlString SummaryBarHtml();

        protected abstract IHtmlString NavigationBarHtml();

        public virtual IHtmlString RenderNavigationHtml()
        {
            return HtmlStringExtensions.Concat(SummaryBarHtml(), NavigationBarHtml());
        }
    }
}
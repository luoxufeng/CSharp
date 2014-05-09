using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    /// <summary>
    /// NavigationViewModel
    /// </summary>
    public class NavigationViewModel : BaseNavigationViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationViewModel" /> class.
        /// </summary>
        /// <param name="currentPageIndex">Index of the current page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalRecordCount">The total record count.</param>
        /// <param name="getUriService">get Uri Service</param>
        /// <param name="listType">Type of the list.</param>
        public NavigationViewModel(int currentPageIndex, int pageSize, int totalRecordCount)
            : base(currentPageIndex, pageSize, totalRecordCount)
        {
           
        }

        /// <summary>
        /// 显示分页数量
        /// </summary>
        protected const int PerPageCount = 5;

        /// <summary>
        /// 类型
        /// </summary>
        protected int ListType { get; set; }

        /// <summary>
        /// 上一页PageIndex
        /// </summary>
        protected int PrePageIndex
        {
            get
            {
                return  this.CurrentPageIndex - 1;
            }
        }

        /// <summary>
        /// 下一页PageIndex
        /// </summary>
        protected int NextPageIndex
        {
            get
            {
                return this.CurrentPageIndex + 1;
            }
        }

        /// <summary>
        /// Gets the start index of the page.
        /// </summary>
        protected int PageStartIndex
        {
            get
            {
                var startIndex = 1;
                if (CurrentPageIndex > 5)
                    startIndex = CurrentPageIndex - 4;

                return startIndex;
            }
        }

        /// <summary>
        /// Gets the end index of the page.
        /// </summary>
        protected int PageEndIndex
        {
            get
            {
                //var endIndex = this.TotalPageIndex > PerPageCount ? PerPageCount : this.TotalPageIndex;
                var endIndex = 5;
                if (CurrentPageIndex > 5)
                    endIndex = CurrentPageIndex;

                return endIndex;
            }
        }

        /// <summary>
        /// //<p>1-10 / 31250篇游记</p>
        /// </summary>
        protected override IHtmlString SummaryBarHtml()
        {
            var pTag = new TagBuilder("p");
            var pageText = string.Format("1-{0}", this.TotalPageIndex > 0 ? this.TotalPageIndex : 1);//"1-{0}".Format(this.TotalPageIndex > 0 ? this.TotalPageIndex : 1);
            var travelText = string.Format("{0}篇游记", this.TotalRecordCount);

            pTag.SetInnerText(string.Format("{0} / {1}", pageText, travelText));

            return new MvcHtmlString(pTag.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Navigation Bar Link String Html.
        /// </summary>
        protected override IHtmlString NavigationBarHtml()
        {
            // <div class="pager_v1">
            var wrappeDiv = TagBuilderHelper.CreateTagBuilder("div", "class", "pager_v1");
            var connectHtmlSrings = new List<IHtmlString>();
            connectHtmlSrings.Add(this.PreNextPageHtmlString("pre", this.PrePageIndex));

            // TODO: 计算startIndex, endIndex,和PrePageIndex, NextPageIndex.
            //    <a class="current" href="###">1</a>
            //    <a href="###">2</a>
            //    <a href="###">3</a>
            //    <a href="###">4</a>
            //    <a href="###">5</a>
            for (int loop = this.PageStartIndex; loop <= this.PageEndIndex; loop++)
            {
                connectHtmlSrings.Add(this.PageLinkHtmlString(loop));
            }

            connectHtmlSrings.Add(this.PreNextPageHtmlString("next", this.NextPageIndex));

            // <span>到 <input type="text" value=""> 页 / 50页</span>
            var spanTag = new TagBuilder("span");
            spanTag.InnerHtml = string.Format("到 {0} 页 / {1}页", InputButtonHtmlString().ToHtmlString(), LimitedPageNumberHtmlString(this.TotalPageIndex).ToHtmlString());

            //    <a class="gopage" href="###">确定</a>
            var confirmALink = TagBuilderHelper.CreateTagBuilder("a", "class", "gopage");
            confirmALink.MergeAttribute("href", "javascript:;");
            confirmALink.SetInnerText("确定");

            // 组合html string
            wrappeDiv.InnerHtml = string.Concat(connectHtmlSrings.Select(item => item.ToHtmlString()));
            wrappeDiv.InnerHtml += spanTag.ToString();
            wrappeDiv.InnerHtml += confirmALink.ToString();

            return new MvcHtmlString(wrappeDiv.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        protected IHtmlString PreNextPageHtmlString(string type, int index)
        {
            var tag = new TagBuilder("a");
            var text = string.Empty;

            switch (type)
            {
                case "pre":
                    tag.MergeAttribute("class", "prevpage");

                    if (this.CurrentPageIndex == 1)
                    {
                        tag.Attributes["class"] = string.Join(" ", tag.Attributes["class"], "disabled");
                    }

                    text = "<i></i>上一页";
                    break;
                case "next":
                    tag.MergeAttribute("class", "nextpage");

                    if (this.PageStartIndex + PerPageCount >= this.TotalPageIndex)
                    {
                        tag.Attributes["class"] = string.Join(" ", tag.Attributes["class"], "disabled");
                    }

                    text = "下一页<i></i>";
                    break;
                default:
                    tag.MergeAttribute("class", "");
                    break;
            }

            tag.MergeAttribute("href", this.GetPageUrl(index));
            tag.InnerHtml = text;

            return new MvcHtmlString(tag.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        protected IHtmlString PageLinkHtmlString(int pageIndex)
        {
            var tag = new TagBuilder("a");
            tag.MergeAttribute("href", this.GetPageUrl(pageIndex));

            if (pageIndex == this.CurrentPageIndex)
            {
                tag.MergeAttribute("class", "current");
            }

            tag.SetInnerText(pageIndex.ToString());

            return new MvcHtmlString(tag.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected IHtmlString InputButtonHtmlString()
        {
            var tag = new TagBuilder("input");
            tag.MergeAttribute("type", "text");
            tag.MergeAttribute("value", "");
            tag.MergeAttribute("lt", this.ListType.ToString());

            return new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        /// Limiteds the page number HTML string.
        /// </summary>
        private IHtmlString LimitedPageNumberHtmlString(int pageNum)
        {
            var tag = new TagBuilder("em");
            tag.AddCssClass("numpage");

            tag.SetInnerText(pageNum.ToString());

            return new MvcHtmlString(tag.ToString());
        }

        /// <summary>
        /// Gets the page URL.
        /// </summary>
        protected string GetPageUrl(int index)
        {
            if (index < 1)
            {
                return "javascript:;";
            }
            else if (index > this.TotalPageIndex)
            {
                return string.Format("/Page/Index?pagenow={0}", TotalPageIndex);
                    //this.GetUriService(this.TotalPageIndex);
            }

            return string.Format("/Page/Index?pagenow={0}", index);
        }
    }
}
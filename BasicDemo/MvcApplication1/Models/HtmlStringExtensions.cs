using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public static class HtmlStringExtensions
    {
        public static IHtmlString Concat(this IHtmlString htmlString, params IHtmlString[] hstrings)
        {
            var strings = htmlString.ToHtmlString();

            if (hstrings != null && hstrings.Any())
            {
                strings = string.Concat(strings, string.Join(string.Empty, hstrings.Select(_ => _.ToHtmlString())));
            }

            return new HtmlString(strings);
        }
    }
}
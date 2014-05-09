using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public static class TagBuilderHelper
    {
        /// <summary>
        /// Creates the tag builder.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="className">Name of the class.</param>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <returns>return tag builder</returns>
        public static TagBuilder CreateTagBuilder(string tagName, string className = "", string attributeName = "")
        {
            var tag = new TagBuilder(tagName);

            if (!string.IsNullOrWhiteSpace(className))
            {
                tag.MergeAttribute(className, attributeName);
            }

            return tag;
        }
    }
}
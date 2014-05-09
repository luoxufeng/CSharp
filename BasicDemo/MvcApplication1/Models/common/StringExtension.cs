using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace MvcApplication1.Models.common
{
    public static class StringExtension
    {
        /// <summary>
        /// Create the Uri safely not throwing any exceptions.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        /// return the created uri.
        /// </returns>
        public static Uri CreateUri(this string url)
        {
            Uri uri;

            if (!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out uri))
            {
                return null;
            }

            return uri;
        }

        /// <summary>
        /// Tries the parse to.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>return the pared T type.</returns>
        public static T TryParseTo<T>(this string value, T defaultValue = default(T))
        {
            try
            {
                return value.ParseTo(defaultValue);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Parses to.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>return the pared T type.</returns>
        public static T ParseTo<T>(this string value, T defaultValue)
        {
            T obj = defaultValue;

            if (!string.IsNullOrEmpty(value))
            {
                obj = (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value);
            }

            return obj;
        }

        /// <summary>
        /// Formats the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="objs">The objs.</param>
        /// <returns>return the formated string.</returns>
        public static string Format(this string format, params object[] objs)
        {
            return string.Format(format, objs);
        }

        /// <summary>
        /// Combines the URI.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="uriParts">The URI parts.</param>
        /// <returns>return the combined uri string.</returns>
        public static string CombineUri(this string text, params string[] uriParts)
        {
            var baseUri = text;

            if (!string.IsNullOrWhiteSpace(text) && uriParts != null && uriParts.Any())
            {
                char[] trims = { '\\', '/' };
                baseUri = uriParts.Aggregate(baseUri,
                    (first, second) => string.Format("{0}/{1}", first.TrimEnd(trims), (second ?? string.Empty).TrimStart(trims)));
            }

            return baseUri;
        }
    }
}
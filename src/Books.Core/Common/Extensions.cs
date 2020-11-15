using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Core.Common
{
    public static class Extensions
    {
        public static string IsValueNullOrEmpty(this string key, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception($"{value} is empty or not set.");
            }
            return value;
        }

        public static void Each<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }

    }
}

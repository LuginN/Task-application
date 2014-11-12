using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

namespace TaskApp.Extensions
{
    public static class EnumExtension
    {
        public static String ToDescription(this Enum value)
        {
            var attributes = (DescriptionAttribute[])value
                .GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Select(x => x.Description).Concat(new [] {value.ToString()}).First();
        }

        public static IEnumerable<SelectListItem> ToSelectList(this Enum value)
        {
            return from Enum e in Enum.GetValues(value.GetType())
                   select new SelectListItem()
                   {
                       Selected = e.Equals(value),
                       Text = e.ToDescription(),
                       Value = e.ToString()
                   };
        }
    }
}

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
            var atr = attributes.Length > 0 ? attributes[0].Description : value.ToString();
            return atr;
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
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using SYGESTMunicipal.Data;
using System.Threading.Tasks;

namespace SYGESTMunicipal.Extensions
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<SelectListItem>
            ToSelectListItem<T>(this IEnumerable<T> items, int selectedValue)
        {
            return from item in items
                   select new SelectListItem
                   {
                       Text = item.GetPropertyValue("Nombre"),
                       Value = item.GetPropertyValue("Id"),
                       Selected = item.GetPropertyValue("Id").Equals(selectedValue.ToString())
                   };
        }
    }
}
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.Product.Models
{
    public class IProducts
    {
        IEnumerable<Item> ProductCategories { get; set; }
    }
}
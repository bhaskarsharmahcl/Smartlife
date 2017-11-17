namespace Sitecore.Feature.Product.Repositories
{
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Feature.Product.Models;
    using Sitecore.Foundation.SitecoreExtensions.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class ProductRepository : IProductRepository
    {
        
        public ProductDetail Get(Item contextItem)
        {
            var item = contextItem;
            return new ProductDetail
            {
                ProductItem = item
            };
        }

        public Products GetProducts(Item contextItem)
        {
            Products products = new Products();
            IEnumerable<Item> childrenFromItem = ProductRepository.GetChildrenFromItem(contextItem, Templates.ProductCategory.ID);
            products.ProductCategories = childrenFromItem;
    //        foreach (Item current in products.ProductCategories)
    //        {
    //            IEnumerable<Item> arg_57_0 = current.Children;
    //            Func<Item, bool> arg_57_1;
    //            if ((arg_57_1 = ProductRepository.<> c.<> 9__1_0) == null)
				//{
    //                arg_57_1 = (ProductRepository.<> c.<> 9__1_0 = new Func<Item, bool>(ProductRepository.<> c.<> 9.< GetProducts > b__1_0));
    //            }
    //            arg_57_0.Where(arg_57_1);
    //        }
            return products;
        }

        private static IEnumerable<Item> GetChildrenFromItem(Item item, ID templateId)
        {
            return from i in item.Children
                   where i.IsDerived(templateId)
                   select i;
        }

   //     private static IEnumerable<Item> GetItemsFromMultiList(Item item)
   //     {
   //         IEnumerable<Item> multiListValueItems = item.GetMultiListValueItems(Templates.HasProductSelector.Fields.ProductSelector);
   //         IEnumerable<Item> arg_2D_0 = multiListValueItems;
   //         Func<Item, bool> arg_2D_1;
   //         if ((arg_2D_1 = ProductRepository.<> c.<> 9__3_0) == null)
			//{
   //             arg_2D_1 = (ProductRepository.<> c.<> 9__3_0 = new Func<Item, bool>(ProductRepository.<> c.<> 9.< GetItemsFromMultiList > b__3_0));
   //         }
   //         return arg_2D_0.Where(arg_2D_1);
   //     }
    }
}
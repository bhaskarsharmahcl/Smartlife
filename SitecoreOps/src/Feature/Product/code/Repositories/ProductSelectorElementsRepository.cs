namespace Sitecore.Feature.Product.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sitecore.Data.Items;
    using Sitecore.Feature.Product.Models;
    using Sitecore.Foundation.SitecoreExtensions.Extensions;
    using Sitecore.Mvc.Extensions;
    
    public static class ProductSelectorElementsRepository
    {
        public static IEnumerable<ProductSelectorElement> Get([NotNull] Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            var items = GetItemsFromMultiList(item).ToArray();
            if (!items.Any())
                items = GetMediaFromChildren(item).ToArray();

            foreach (var child in items)
            {
                if (child.IsDerived(Templates.HasProductSelector.ID) && child[Templates.HasPageContent.Fields.Image].IsEmptyOrNull())
                {
                    continue;
                }

                yield return new ProductSelectorElement
                {
                    Item = child,
                };
            }
        }

        private static IEnumerable<Item> GetMediaFromChildren(Item item)
        {
            return item.Children.Where(i => i.IsDerived(Templates.Product.ID));
        }

        private static IEnumerable<Item> GetItemsFromMultiList(Item item)
        {
            var multiListValues = item.GetMultiListValueItems(Templates.HasProductSelector.Fields.ProductSelector);
            return multiListValues.Where(i => i.IsDerived(Templates.Product.ID));
        }
    }
}
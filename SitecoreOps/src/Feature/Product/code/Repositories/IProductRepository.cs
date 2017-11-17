namespace Sitecore.Feature.Product.Repositories
{
    using Sitecore.Data.Items;
    using Sitecore.Feature.Product.Models;

    public interface IProductRepository
    {
        ProductDetail Get(Item contextItem);
        Products GetProducts(Item contextItem);
    }
}
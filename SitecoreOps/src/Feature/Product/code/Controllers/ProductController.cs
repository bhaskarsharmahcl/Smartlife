using Sitecore.Feature.Product.Repositories;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace Sitecore.Feature.Product.Controllers
{
    public class ProductController : SitecoreController
    {
        private IProductRepository repository;

        public ProductController() : this(new ProductRepository())
        {

        }

        public ProductController (IProductRepository repository)
        {
            this.repository = repository;
        }
        public ActionResult ProductDetail()
        {
            return View(repository.Get(RenderingContext.Current.ContextItem));
        }
        public ActionResult Products()
        {
            return base.View(this.repository.GetProducts(RenderingContext.Current.ContextItem));
        }
    }
}
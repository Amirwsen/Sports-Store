using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public int PageSize = 4;

        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        // public IActionResult Index() => View(repository.Products);

        public ViewResult Index(string? Category,int productPage = 1)
            => View(new ProductsListViewModel {
                Products = repository.Products
                    .Where(p => Category == null || p.Category == Category)
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize) .Take(PageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = Category == null
                    ? repository.Products.Count()
                    : repository.Products.Where(e => e.Category == Category).Count()
                },
                CurrentCategory = Category
            });
    }
}




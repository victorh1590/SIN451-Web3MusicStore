using Microsoft.AspNetCore.Mvc;
using Web3MusicStore.API.Models;

namespace Web3MusicStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StoreController : Controller
{
  private IStoreRepository _repository;
  public int PageSize = 4;

  public StoreController(IStoreRepository repository)
  {
    _repository = repository;
  }

  // public IActionResult Index() => View(_repository.Products); // Send products from repository to view.

  //   public ViewResult Index(int productPage = 1) 
  //     => View(_repository.Products
  //     .OrderBy(p => p.ProductID)
  //     .Skip((productPage - 1) * PageSize)
  //     .Take(PageSize));
  // }

  // public ViewResult Index(string? category, int productPage = 1) => View(new ProductsListViewModel
  // {
  // Products = _repository.Products
  // .Where(p => category == null || p.Category == category)
  // .OrderBy(p => p.ProductID)
  // .Skip((productPage - 1) * PageSize)
  // .Take(PageSize),
  // PagingInfo = new PagingInfo
  // {
  // CurrentPage = productPage,
  // ItemsPerPage = PageSize,
  // TotalItems = (category == null ? 
  // _repository.Products.Count() : _repository.Products.Where(e => e.Category == category).Count())
  // },
  // CurrentCategory = category
  // });

  [HttpGet("", Name = "GetProduct")]
  public IActionResult Get()
  {
    if (_repository.Products is null)
    {
      return NotFound();
    }

    return Ok(_repository.Products);
  }

  [HttpGet("{productID}", Name = "GetProductById")]
  public IActionResult GetById(long productID)
  {
    var item = _repository.Products.Select(x => x).Where(x => x.ProductID == productID);
    if (item is null)
    {
      return NotFound();
    }

    return Ok(item);
  }
}
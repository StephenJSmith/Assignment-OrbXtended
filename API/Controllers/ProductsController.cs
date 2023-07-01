using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers;

public class ProductsController : BaseApiController {
    private readonly IProductsRepository _repository;
    private readonly IConfiguration _configuration;
    private readonly string _defaultSortField;
    private readonly string _defaultSortOrder;
    private readonly int _defaultSkipItems;
    private readonly int _defaultTakeItems;

    public ProductsController(
      IProductsRepository repository,
      IConfiguration configuration)
  {
    _repository = repository;
    _configuration = configuration;
    _defaultSortField = _configuration["TopProducts:SortField"];
    _defaultSortOrder = _configuration["TopProducts:SortOrder"];
    _defaultSkipItems = int.Parse(_configuration["TopProducts:SkipItems"]);
    _defaultTakeItems =  int.Parse(_configuration["TopProducts:TakeItems"]);
  }

  [HttpGet]
  public ActionResult<List<Product>> GetProducts() {
    return _repository.GetProducts();
  }

  [HttpGet("top/{simulator}")]
  public ActionResult<List<Product>> GetTopProductsForSimulator(string simulator) {
    var result = _repository.GetTopProductsForSimulator(
      simulator, _defaultSortField, _defaultSortOrder, _defaultSkipItems, _defaultTakeItems);

      return Ok(result);
  }

  [HttpGet("simulators")]
  public ActionResult<List<string>> GetSimulators() {
    return _repository.GetSimulators();
  }
}
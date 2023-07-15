using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Application.Products;

namespace API.Controllers;

public class ProductsController : BaseApiController
{
  private readonly IConfiguration _configuration;
  private readonly string _defaultSortField;
  private readonly string _defaultSortOrder;
  private readonly int _defaultSkipItems;
  private readonly int _defaultTakeItems;

  public ProductsController(
    IConfiguration configuration)
  {
    _configuration = configuration;
    _defaultSortField = _configuration["TopProducts:SortField"];
    _defaultSortOrder = _configuration["TopProducts:SortOrder"];
    _defaultSkipItems = int.Parse(_configuration["TopProducts:SkipItems"]);
    _defaultTakeItems = int.Parse(_configuration["TopProducts:TakeItems"]);
  }

  [HttpGet]
  public async Task<ActionResult<List<Product>>> GetProducts()
  {
    return await Mediator.Send(new ListProducts.Query());
  }

  [HttpGet("top/{simulator}")]
  public async Task<ActionResult<List<Product>>> GetTopProductsForSimulator(string simulator)
  {

    var result = await Mediator.Send(new ListProductsForSimulator.Query
    {
      Simulator = simulator,
      SortField = _defaultSortField,
      SortOrder = _defaultSortOrder,
      SkipItems = _defaultSkipItems,
      TakeItems = _defaultTakeItems
    });

    return Ok(result);
  }

  private string Coalesce(string stringValue, string defaultValue)
  {
    return !string.IsNullOrWhiteSpace(stringValue)
      ? stringValue
      : defaultValue;
  }

  private int Coalesce(int intValue, int defaultValue)
  {
    return intValue > 0
      ? intValue
      : defaultValue;
  }

  [HttpGet("paged/{simulator}")]
  public async Task<ActionResult<List<Product>>> GetPagedProductsForSimulator(string simulator, string sort = "", string order = "", int skip = 0, int take = 0)
  {

    var page = new ListProductsForSimulator.Query
    {
      Simulator = simulator,
      SortField = Coalesce(sort, _defaultSortField),
      SortOrder = Coalesce(order, _defaultSortOrder),
      SkipItems = Coalesce(skip, _defaultSkipItems),
      TakeItems = Coalesce(take, _defaultTakeItems)
    };

    var result = await Mediator.Send(new ListProductsForSimulator.Query
    {
      Simulator = page.Simulator,
      SortField = page.SortField,
      SortOrder = page.SortOrder,
      SkipItems = page.SkipItems,
      TakeItems = page.TakeItems
    });

    return Ok(result);
  }

  [HttpGet("simulators")]
  public async Task<ActionResult<List<string>>> GetSimulators()
  {
    return await Mediator.Send(new ListSimulators.Query());
  }
}
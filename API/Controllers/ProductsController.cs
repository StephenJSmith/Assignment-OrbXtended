using Domain;
using API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Application.Products;
using Application.Extensions;

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

  [HttpGet()]
  public async Task<IActionResult> GetProducts()
  {
    return HandleResult(await Mediator.Send(new ListProducts.Query()));
  }

  [HttpGet("settings")]
  public async Task<IActionResult> GetProductsSettings() {
    var result = await Mediator.Send(new ProductsSettings.Query {
      DefaultSortField = _defaultSortField,
      DefaultSortOrder = _defaultSortOrder,
      DefaultSkipItems = _defaultSkipItems,
      DefaultTakeItems = _defaultTakeItems
    });

    return HandleResult(result);
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

    return HandleResult(result);
  }

  [HttpGet("page/{simulator}")]
  public async Task<IActionResult> GetPagedProductsForSimulator(
    string simulator, 
    string sort, 
    string order, 
    int skip, 
    int take)
  {
    var page = new ListProductsForSimulator.Query
    {
      Simulator = simulator,
      SortField = sort.OrDefaultValue(_defaultSortField),
      SortOrder = order.OrDefaultValue(_defaultSortOrder),
      SkipItems = skip.OrDefaultValue(_defaultSkipItems),
      TakeItems = take.OrDefaultValue(_defaultTakeItems)
    };

    var result = await Mediator.Send(new ListProductsForSimulator.Query
    {
      Simulator = page.Simulator,
      SortField = page.SortField,
      SortOrder = page.SortOrder,
      SkipItems = page.SkipItems,
      TakeItems = page.TakeItems
    });

    return HandleResult(result);
  }

  [HttpGet("dto/{simulator}")]
  public async Task<IActionResult> GetDtoProductsForSimulator(GetPagedProductsForSimulatorDto dto) {
    var result = await Mediator.Send(new ListProductsForSimulator.Query
    {
      Simulator = dto.Simulator,
      SortField = dto.Sort,
      SortOrder = dto.Order,
      SkipItems = dto.Skip,
      TakeItems = dto.Take
    });

    return HandleResult(result);
  }

  [HttpGet("simulators")]
  public async Task<IActionResult> GetSimulators()
  {
    return HandleResult(await Mediator.Send(new ListSimulators.Query()));
  }
}

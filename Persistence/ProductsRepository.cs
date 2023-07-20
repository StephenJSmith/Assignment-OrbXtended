using Domain;

namespace Persistence;

public class ProductsRepository : IProductsRepository
{
  public static string Fsx = "fsx";
  public static string Fsxe = "fsxe";
  public static string P3dv1 = "p3dv1";
  public static string P3dv2 = "p3dv2";
  public static string P3dv3 = "p3dv3";
  public static string P3dv4 = "p3dv4";
  public static string P3dv5 = "p3dv5";
  public static string Msfs = "msfs";
  public static string Xp11 = "xp11";
  public static string Afs2 = "afs2";

  private readonly List<Product> _products;
  private readonly List<string> _simulators;

  private const string IdField = "Id";
  private const string NameField = "Name";
  private const string AirportField = "Airport";
  private const string CurrentPriceField = "CurrentPrice";
  private const string CurrentPriceDisplay = "Current Price";
  private const string IcaoField = "ICAO";
  private const string PlatformField = "Platform";

  public ProductsRepository()
  {
    _products = ProductsSeedFactory.GetProducts();
    _simulators = GetSeededSimulators();
  }

  public List<Product> GetProducts()
  {
    return _products.ToList();
  }

  public Task<List<Product>> GetProductsAsync()
  {
    return Task.Run(() => _products.ToList());
  }

  public Dictionary<string, string> GetSortableProductFields() {
    return new Dictionary<string, string> {
      { CurrentPriceField, CurrentPriceDisplay },
      { NameField, NameField },
      { AirportField, AirportField },
      { IcaoField, IcaoField }
    };
  }

  public Task<Dictionary<string, string>> GetSortableProductFieldsAsync() {
    return Task.Run(() => GetSortableProductFields());
  }

  public List<Product> GetTopProductsForSimulator(
    string simulator, string sortField, string sortOrder, int skipItems, int takeItems)
  {
    var expression = _products
      .Where(p => p.Simulators.Any(s => s == simulator.ToLower()))
      .Skip(skipItems)
      .Take(takeItems);

    var isDescendingOrder = sortOrder.ToLower() == "desc";
    var isAscendingOrder = sortOrder.ToLower() == "asc";

    switch (sortField.ToLower())
    {
      case "id":
        if (isDescendingOrder)
        {
          expression = expression.OrderByDescending(p => p.Id);          
        } else {
          expression = expression.OrderBy(p => p.Id);
        }
        break;

      case "name":
        if (isDescendingOrder)
        {
          expression = expression.OrderByDescending(p => p.Name);          
        } else {
          expression = expression.OrderBy(p => p.Name);
        }
        break;

      case "airport":
        if (isDescendingOrder)
        {
          expression = expression.OrderByDescending(p => p.Airport);          
        } else {
          expression = expression.OrderBy(p => p.Airport);
        }
        break;

      case "icao":
        if (isDescendingOrder)
        {
          expression = expression.OrderByDescending(p => p.Icao);
        } else {
          expression = expression.OrderBy(p => p.Icao);
        }
        break;

      case "platform":
        if (isDescendingOrder)
        {
          expression = expression.OrderByDescending(p => p.Platform);          
        } else {
          expression = expression.OrderBy(p => p.Platform);
        }
        break;

      default:
        if (isAscendingOrder)
        {
          expression = expression.OrderBy(p => p.CurrentPrice);
        } else {
          expression = expression.OrderByDescending(p => p.CurrentPrice);          
        }

        break;
    }

    var results = expression
      .ToList();

    return results;
  }

  public Task<List<Product>> GetTopProductsForSimulatorAsync(string simulator, string sortField, string sortOrder, int skipItems, int takeItems)
  {
    return Task.Run(() => GetTopProductsForSimulator(simulator, sortField, sortOrder, skipItems, takeItems));
  }

  public List<string> GetSimulators()
  {
    return _simulators.ToList();
  }

  public Task<List<string>> GetSimulatorsAsync()
  {
    return Task.Run(() => GetSimulators());
  }

  private List<string> GetSeededSimulators()
  {
    return new List<string> {
                      Fsx, Fsxe,
                      P3dv1, P3dv2, P3dv2, P3dv3, P3dv4, P3dv5,
                      Msfs, Xp11, Afs2
        };
  }
}
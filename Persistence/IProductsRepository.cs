using Domain;

namespace Persistence;

public interface IProductsRepository {
  List<Product> GetProducts();
  Task<List<Product>> GetProductsAsync();
  Dictionary<string, string> GetSortableProductFields();
  Task<Dictionary<string, string>> GetSortableProductFieldsAsync();
  List<Product> GetTopProductsForSimulator(
    string simulator, string sortField, string sortOrder, int skipItems, int takeItems);
  Task<List<Product>> GetTopProductsForSimulatorAsync(
    string simulator, string sortField, string sortOrder, int skipItems, int takeItems);
  List<string> GetSimulators();
  Task<List<string>> GetSimulatorsAsync();
}
using Domain;

namespace Persistence;

public interface IProductsRepository {
  List<Product> GetProducts();
  List<Product> GetTopProductsForSimulator(
    string simulator, string sortField, string sortOrder, int skipItems, int takeItems);
  List<string> GetSimulators();
}
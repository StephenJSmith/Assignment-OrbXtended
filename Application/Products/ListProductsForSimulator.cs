using Domain;
using MediatR;
using Persistence;

namespace Application.Products;

public class ListProductsForSimulator
{
  public class Query : IRequest<List<Product>>
  {
    public string Simulator { get; set; }
    public string SortField { get; set; }
    public string SortOrder { get; set; }
    public int SkipItems { get; set; }
    public int TakeItems { get; set; }
  }

  public class Handler : IRequestHandler<Query, List<Product>>
  {
    private readonly IProductsRepository _repository;

    public Handler(IProductsRepository repository)
    {
      _repository = repository;
    }

    public async Task<List<Product>> Handle(Query request, CancellationToken cancellationToken)
    {
      return await _repository.GetTopProductsForSimulatorAsync(
        request.Simulator, 
        request.SortField, 
        request.SortOrder, 
        request.SkipItems,
        request.TakeItems
      );
    }
  }
}
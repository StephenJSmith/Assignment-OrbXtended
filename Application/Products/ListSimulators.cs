using MediatR;
using Persistence;

namespace Application.Products;

public class ListSimulators
{
  public class Query : IRequest<List<string>> { }

  public class Handler : IRequestHandler<Query, List<string>>
  {
    private readonly IProductsRepository _repository;
    public Handler(IProductsRepository repository)
    {
      _repository = repository;
    }

    public async Task<List<string>> Handle(Query request, CancellationToken cancellationToken)
    {
      return await _repository.GetSimulatorsAsync();
    }
  }
}
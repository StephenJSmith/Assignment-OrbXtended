using Application.Core;
using MediatR;
using Persistence;

namespace Application.Products;

public class ListSimulators
{
  public class Query : IRequest<Result<List<string>>> { }

  public class Handler : IRequestHandler<Query, Result<List<string>>>
  {
    private readonly IProductsRepository _repository;
    public Handler(IProductsRepository repository)
    {
      _repository = repository;
    }

    public async Task<Result<List<string>>> Handle(Query request, CancellationToken cancellationToken)
    {
      return Result<List<string>>.Success(await _repository.GetSimulatorsAsync());
    }
  }
}
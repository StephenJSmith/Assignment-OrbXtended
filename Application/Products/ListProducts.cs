using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Products;

public class ListProducts
{
  public class Query : IRequest<Result<List<Product>>> { }

  public class Handler : IRequestHandler<Query, Result<List<Product>>>
  {
    private readonly IProductsRepository _repository;

    public Handler(IProductsRepository repository)
    {
      _repository = repository;
    }

    public async Task<Result<List<Product>>> Handle(
      Query request, 
      CancellationToken cancellationToken)
    {
      var result = await _repository.GetProductsAsync();

      return Result<List<Product>>.Success(result);
    }
  }
}
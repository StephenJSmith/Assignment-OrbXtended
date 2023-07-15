using Domain;
using MediatR;
using Persistence;

namespace Application.Products;

public class ListProducts
{
  public class Query : IRequest<List<Product>> { }

  public class Handler : IRequestHandler<Query, List<Product>>
  {
    private readonly IProductsRepository _repository;

    public Handler(IProductsRepository repository)
    {
      _repository = repository;
    }

    public async Task<List<Product>> Handle(Query request, CancellationToken cancellationToken)
    {
      return await _repository.GetProductsAsync();
    }
  }
}
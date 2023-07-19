using Application.Core;
using Application.Dtos;
using MediatR;
using Persistence;

namespace Application.Products;

public class InitialPagination
{
  public class Query : IRequest<Result<InitialPaginationDto>>
  {
    public string DefaultSortField { get; set; }
    public string DefaultSortOrder { get; set; }
    public int DefaultSkipItems { get; set; }
    public int DefaultTakeItems { get; set; }
  }

  public class Handler : IRequestHandler<Query, Result<InitialPaginationDto>>
  {
    private readonly IProductsRepository _repository;

    public Handler(IProductsRepository repository)
    {
      _repository = repository;
    }

    public async Task<Result<InitialPaginationDto>> Handle(
      Query request, 
      CancellationToken cancellationToken)
    {
      var sortableFields = new List<SortableField>();

      Dictionary<string, string> sortableFieldsDictionary = await _repository.GetSortableProductFieldsAsync();
      foreach (var kvp in sortableFieldsDictionary) 
      {
        sortableFields.Add(new SortableField{
          Field = kvp.Key,
          Display = kvp.Value,
          IsSortField = kvp.Key == request.DefaultSortField
        });
      };

      var result = new InitialPaginationDto {
        SortableFields = sortableFields,
        Order = request.DefaultSortOrder,
        Skip = request.DefaultSkipItems,
        Take = request.DefaultTakeItems,
      };

      return Result<InitialPaginationDto>.Success(result);  
    }
  }
}
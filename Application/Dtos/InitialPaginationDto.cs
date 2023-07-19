namespace Application.Dtos;

public class InitialPaginationDto {
  public List<SortableField> SortableFields { get; set; }
  public string Order { get; set; }
  public int Skip { get; set; }
  public int Take { get; set; }
}

public class SortableField {
  public string Field { get; set; }
  public string Display { get; set; }
  public bool IsSortField { get; set; }
}
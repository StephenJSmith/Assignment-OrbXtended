namespace Application.Dtos;

public class ProductSettingsDto {
  public List<string> Simulators { get; set; }
  public List<SortableField> SortableFields { get; set; }
  public string Order { get; set; }
  public int Skip { get; set; }
  public int Take { get; set; }
  public int MaxTake { get; set; }
}

public class SortableField {
  public string Field { get; set; }
  public string Display { get; set; }
  public bool IsSortField { get; set; }
}
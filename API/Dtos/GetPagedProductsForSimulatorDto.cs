namespace API.Dtos;

public class GetPagedProductsForSimulatorDto
{
  public string Simulator { get; set; }
  public string Sort { get; set; }
  public string Order { get; set; }
  public int Skip { get; set; }
  public int Take { get; set; }
}
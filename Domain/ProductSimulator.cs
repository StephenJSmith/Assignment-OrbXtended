namespace Domain;

public class ProductSimulator {
  public static ProductSimulator Create(int produtId, string simulatorId) {
    return new ProductSimulator{
      ProductId = produtId,
      SimulatorId = simulatorId
    };
  }

  public int ProductId { get; set; }
  public string SimulatorId { get; set; }
}
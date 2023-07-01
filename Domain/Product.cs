using System.Reflection.Metadata.Ecma335;

namespace Domain;

public class Product
{
  public static Product Create(int id, string name, string platform, decimal currentPrice, string link) {
    return new Product {
      Id = id,
      Name = name,
      Platform = platform,
      CurrentPrice = currentPrice,
      Link = link
    };
  }

  public int Id { get; set; }
  public string Name { get; set; }
  public string Platform { get; set; }
  public decimal CurrentPrice { get; set; }
  public string Link { get; set; }
  public List<string> Simulators { get; set; }
}

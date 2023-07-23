namespace Persistence;

public class JsonProduct {
  public int id { get; set; }
  public string name { get; set; }
  public string platform { get; set; }
  public string icao { get; set; }
  public List<string> simulators { get; set; }
  public string image_header { get; set; }
  public Price price { get; set; }
  public string link { get; set; }
}

public class Price {
  public float standard { get; set; }
  public float current { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Simulator {
  public static Simulator Create(string id) {
    return new Simulator{Id = id};
  }

  public string Id { get; set; }
}

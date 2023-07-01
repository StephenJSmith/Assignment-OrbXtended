using Domain;

namespace Persistence;

public static class Seed
{
  public static Simulator Fsx = new Simulator {Id = "fsx"};
  public static Simulator Fsxe = new Simulator {Id = "fsxe"};
  public static Simulator P3dv1 = new Simulator {Id = "p3dv1"};
  public static Simulator P3dv2 = new Simulator {Id = "p3dv2"};
  public static Simulator P3dv3 = new Simulator {Id = "p3dv3"};
  public static Simulator P3dv4 = new Simulator {Id = "p3dv4"};
  public static Simulator P3dv5 = new Simulator {Id = "p3dv5"};
  public static Simulator Msfs = new Simulator {Id = "msfs"};
  public static Simulator Xp11 = new Simulator{Id = "xp11"};
  public static Simulator Afs2 = new Simulator{Id = "afs2"};

  public static async Task SeedData(DataContext context)
  {
    var simulators = new List<Simulator> {
      Fsx, Fsxe,
      P3dv1, P3dv2, P3dv2, P3dv3, P3dv4, P3dv5,
      Msfs, Xp11, Afs2
    };
    await context.Simulators.AddRangeAsync(simulators);
    
    var products = new List<Product> {
                new Product {
                    Id = 84,
                    Name = "05S Vernonia Municipal Airport",
                    Platform = "FSX & Prepar3D",
                    CurrentPrice = 29.95m,
                    Link = "https://orbxdirect.com/product/05s",
                    // Simulators = new List<Simulator>() {
                    //   Fsx.Id, Fsxe.Id,
                    //   P3dv1.Id, P3dv2.Id, P3dv2.Id, P3dv3.Id, P3dv4.Id, P3dv5.Id
                    // }
                },
                new Product {
                    Id = 85,
                    Name = "0S9 Jefferson County International",
                    Platform = "FSX & Prepar3D",
                    CurrentPrice = 34.95m,
                    Link = "https://orbxdirect.com/product/0S9",
                    // Simulators = new List<Simulator> {
                    //   Fsx.Id, Fsxe.Id,
                    //   P3dv1.Id, P3dv2.Id, P3dv2.Id, P3dv3.Id, P3dv4.Id, P3dv5.Id
                    // }
                },
                // new Product {
                //     Id = 86,
                //     Name = "11S Sekiu Airport",
                //     Platform = "FSX & Prepar3D",
                //     CurrentPrice = 32.95m,
                //     Link = "https://orbxdirect.com/product/11s",
                //     Simulators = new List<Simulator> {
                //       Fsx, Fsxe,
                //       P3dv1, P3dv2, P3dv2, P3dv3, P3dv4, P3dv5
                //     }
                // },
                // new Product {
                //     Id = 87,
                //     Name = "1S2 Darrington Municipal Airport",
                //     Platform = "FSX & Prepar3D",
                //     CurrentPrice = 32.95m,
                //     Link = "https://orbxdirect.com/product/1s2",
                //     Simulators = new List<Simulator> {
                //       Fsx, Fsxe,
                //       P3dv1, P3dv2, P3dv2, P3dv3, P3dv4, P3dv5
                //     }
                // },
                new Product {
                    Id = 433,
                    Name = "1S2 Darrington Municipal Airport",
                    Platform = "Microsoft Flight Simulator",
                    CurrentPrice = 16.99m,
                    Link = "https://orbxdirect.com/product/1s2-msfs",
                    // Simulators = new List<Simulator> {
                    //   Msfs.Id
                    // }
                },
                new Product {
                    Id = 280,
                    Name = "1S2 Darrington Municipal Airport",
                    Platform =  "X-Plane 11",
                    CurrentPrice = 32.95m,
                    Link = "https://orbxdirect.com/product/1s2-msfs",
                    // Simulators = new List<Simulator> {
                    //   Xp11.Id
                    // }
                },
            };

    await context.Products.AddRangeAsync(products);

    await context.SaveChangesAsync();
  }
}
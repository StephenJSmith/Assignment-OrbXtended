using Domain;

namespace Persistence;

public class ProductsSeedFactory
{
  private static string Fsx = "fsx";
  private static string Fsxe = "fsxe";
  private static string P3dv1 = "p3dv1";
  private static string P3dv2 = "p3dv2";
  private static string P3dv3 = "p3dv3";
  private static string P3dv4 = "p3dv4";
  private static string P3dv5 = "p3dv5";
  private static string Msfs = "msfs";
  private static string Xp11 = "xp11";
  private static string Afs2 = "afs2";

  private static string FsxAndPrepar3d = "FSX & Prepar3D";
  private static string Prepar3Dv4 = "Prepar3D v4";
  private static string MsFlightSimulator = "Microsoft Flight Simulator";
  private static string XPlane11 = "X-Plane 11";

  private static string GetLink(string name)
  {
    var segments = name.Split(' ');
    var segment = segments[0].Replace('/', '-').ToLower();

    return $"https://orbxdirect.com/product/{segment}";
  }

  private static string GetLinkMsfs(string name) => $"{GetLink(name)}-msfs";
  private static string GetLinkXp11(string name) => $"{GetLink(name)}-xp11";

  public static List<Product> GetProducts()
  {
    var products = new List<Product>
    {
      FsxAndPrepar3dPlatform(84, "05S Vernonia Municipal Airport", 29.95m),
      FsxAndPrepar3dPlatform(85, "0S9 Jefferson County International", 34.95m),
      FsxAndPrepar3dPlatform(86, "11S Sekiu Airport", 32.95m),
      FsxAndPrepar3dPlatform(87, "1S2 Darrington Municipal Airport", 32.95m),
      MsFlightSimulatorPlatform(433, "1S2 Darrington Municipal Airport", 16.99m),
      XPlane11Platform(280, "1S2 Darrington Municipal Airport", 32.95m),
      FsxAndPrepar3dPlatform(88, "1WA6 Fall City Airport", 32.95m),
      FsxAndPrepar3dPlatform(218, "2B2/6B6 Plum Island Airport & Minute Man Air Field", 26.95m),
      XPlane11Platform(217, "2B2/6B6 Plum Island Airport & Minute Man Air Field", 26.95m),
      FsxAndPrepar3dPlatform(145, "2S1 Vashon Island Airport"),
      FsxAndPrepar3dPlatform(89, "2W3 Swanson Airport", 32.95m),
      XPlane11Platform(288, "2W3 Swanson Airport", 32.95m),
      FsxAndPrepar3dPlatformExclV5(89, "2W3 Swanson Airport", 34.95m),
      FsxAndPrepar3dPlatform(91, "3W5 Concrete Municipal Airport", 34.95m),
      MsFlightSimulatorPlatform(443, "3W5 Concrete Municipal Airport", 17.99m),
      Prepar3Dv4Platform_3_4(356, "61B Boulder City Municipal Airport", 34.95m),
      FsxAndPrepar3dPlatformExclV5(92, "65S Bonners Ferry Airport", 32.95m),
      FsxAndPrepar3dPlatformExclV5(93, "74S Anacortes Airport", 34.95m),
      XPlane11Platform(281, "74S Anacortes Airport", 34.95m),
      FsxAndPrepar3dPlatform(94, "77S Creswell (Hobby Field)", 34.95m),
      FsxAndPrepar3dPlatform(95, "7S3 Stark's Twin Oaks Airpark", 32.95m),
      XPlane11Platform(305, "7S3 Stark's Twin Oaks Airpark", 32.95m),
      FsxAndPrepar3dPlatform(305, "7WA3 West Wind Airport")
    };

    return products;
  }

  public static Product FsxAndPrepar3dPlatform(int id, string name, decimal currentPrice = 0m)
  {
    var product = new Product
    {
      Id = id,
      Name = name,
      Platform = FsxAndPrepar3d,
      CurrentPrice = currentPrice,
      Link = GetLink(name),
      Simulators = new List<string>() {
        Fsx, Fsxe,
        P3dv1, P3dv2, P3dv2, P3dv3, P3dv4, P3dv5
      }
    };

    return product;
  }

  public static Product FsxAndPrepar3dPlatformExclV5(int id, string name, decimal currentPrice = 0m)
  {
    var product = new Product
    {
      Id = id,
      Name = name,
      Platform = FsxAndPrepar3d,
      CurrentPrice = currentPrice,
      Link = GetLink(name),
      Simulators = new List<string>() {
        Fsx, Fsxe,
        P3dv1, P3dv2, P3dv2, P3dv3, P3dv4
      }
    };

    return product;
  }

  public static Product Prepar3Dv4Platform_3_4(int id, string name, decimal currentPrice = 0m)
  {
    var product = new Product
    {
      Id = id,
      Name = name,
      Platform = Prepar3Dv4,
      CurrentPrice = currentPrice,
      Link = GetLink(name),
      Simulators = new List<string>() {
        P3dv3, P3dv4
      }
    };

    return product;
  }

  public static Product MsFlightSimulatorPlatform(int id, string name, decimal currentPrice)
  {
    var product = new Product
    {
      Id = id,
      Name = name,
      Platform = MsFlightSimulator,
      CurrentPrice = currentPrice,
      Link = GetLinkMsfs(name),
      Simulators = new List<string> {
        Msfs
      }
    };

    return product;
  }

  public static Product XPlane11Platform(int id, string name, decimal currentPrice)
  {
    var product = new Product
    {
      Id = id,
      Name = name,
      Platform = MsFlightSimulator,
      CurrentPrice = currentPrice,
      Link = GetLinkXp11(name),
      Simulators = new List<string> {
        Xp11
      }
    };

    return product;
  }
}
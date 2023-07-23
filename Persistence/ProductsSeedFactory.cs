using Domain;
using System.Text.Json;

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
  private static string Prepara3Dv4Plus = "Prepar3D v4+";
  private static string Prepar3Dv5 = "Prepar3D v5";
  private static string MsFlightSimulator = "Microsoft Flight Simulator";
  private static string XPlane11 = "X-Plane 11";

  private static string GetLink(string name)
  {
    var segments = name.Split(' ');
    var segment = segments[0].Replace('/', '-').ToLower();

    return $"https://orbxdirect.com/product/{segment}";
  }

  private static string GetLinkWithIcao(string icao)
  {
    return $"https://orbxdirect.com/product/{icao.ToLower()}";
  }

  private static string GetLinkMsfs(string name) => $"{GetLink(name)}-msfs";
  private static string GetLinkMsfsWithIcao(string icao) => $"{GetLinkWithIcao(icao)}-msfs";
  private static string GetLinkXp11(string name) => $"{GetLink(name)}-xp11";
  private static string GetLinkXp11WithIcao(string icao) => $"{GetLinkWithIcao(icao)}-xp11";
  private static string GetIcao(string name) => name.Split(' ')[0].ToLower();
  private static string GetAirport(string name) => name[(name.Split(' ')[0].Length + 1)..];

  public static List<Product> GetProductsFromJson()
  {
    var productsData = File.ReadAllText("../Persistence/seed-data-products.json");
    productsData = productsData.Replace("\n", "");
    productsData = productsData.Replace("\r", "");
    var jsonProducts = JsonSerializer.Deserialize<List<JsonProduct>>(productsData);
    var products = new List<Product>();
    foreach (var jp in jsonProducts)
    {
      products.Add(new Product {
        Id = jp.id,
        Icao = jp.icao,
        Name = jp.name,
        Airport = GetAirport(jp.name),
        Platform = jp.platform,
        CurrentPrice = (decimal)jp.price.current,
        Link = jp.link,
        Simulators = jp.simulators
      });
    }

    return products;
  }

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
      FsxAndPrepar3dPlatform(146, "7WA3 West Wind Airport"),
      FsxAndPrepar3dPlatform(139,  "AYEO Emo Mission"),
      FsxAndPrepar3dPlatform(5,  "AYPY Jacksons International Airport", 39.95m),
      FsxAndPrepar3dPlatformExclV5(147,  "CAC8 Nanaimo Water Aerodrome"),
      Prepar3Dv4Platform_3_4(269, "CAE3 Campbell River Water Aerodrome"),
      FsxAndPrepar3dPlatformExclV5(189, "CAG8 Pender Harbour Seaplane Base"),
      FsxAndPrepar3dPlatform(176, "CAX6 Ganges Water Aerodrome"),
      FsxAndPrepar3dPlatform(96, "CEF4 Airdrie Airpark", 32.95m),
      FsxAndPrepar3dPlatform(148, "CEJ4 Claresholm Industrial Airport"),
      FsxAndPrepar3dPlatform(149, "CEN4 High River Regional Airport"),
      MsFlightSimulatorPlatform(524, "WSSS Singapore Changi Airport", 18.99m, "cloudsurf-wsss-msfs"),
      FsxAndPrepar3dPlatformExclV5(24, "CNK4 Parry Sound Airport", 26.95m),
      FsxAndPrepar3dPlatform(97, "CYBD Bella Coola Airport", 34.95m),
      FsxAndPrepar3dPlatform(98, "CYSE Squamish Airport", 34.95m),
      FsxAndPrepar3dPlatform(99, "CZST Stewart Airport", 34.95m),
      Prepar3Dv5Platform(500,  "EGGP Liverpool John Lennon Airport", 34.95m),
      MsFlightSimulatorPlatform(507,  "EGGP Liverpool John Lennon Airport", 24m, "digitaldesign-eggp"),
      XPlane11Platform(499,  "EGGP Liverpool John Lennon Airport", 24m, "digitaldesign-eggp"),
      Prepar3Dv4Pluslatform(508, "LFLL Lyon–Saint-Exupéry Airport", 37m, "digitaldesign-lfll"),
      XPlane11Platform(509, "LFLL Lyon–Saint-Exupéry Airport", 30m, "digitaldesign-lfll"),
      Prepar3Dv4Pluslatform(520, "LOWS Salzburg Airport", 31m, "digitaldesign-lows"),
      MsFlightSimulatorPlatform(475, "LOWS Salzburg Airport", 28.4m, "digitaldesign-lows"),
      Prepar3Dv4Pluslatform(528, "RJAA Narita International Airport", 31.95m, "drzewiecki-rjaa"),
      XPlane11Platform(529, "RJAA Narita International Airport", 31.95m, "drzewiecki-rjaa"),
      MsFlightSimulatorPlatform(514,  "Drzewiecki Design Warsaw Airfields", 0, "drzewiecki-warsaw-airfields"),
      FsxAndPrepar3dPlatform(140, "EDBH Barth Stralsund Airport", 0),
      FsxAndPrepar3dPlatformExclV5(25, "EDBJ Jena Schoengleina Airport", 26.95m),
      FsxAndPrepar3dPlatform(141, "EDCG Rügen Airport", 0),
      FsxAndPrepar3dPlatform(142, "EDVR Rinteln Airport", 0),
      FsxAndPrepar3dPlatform(26, "EDVY Porta Westfalica Airport", 26.95m),
      XPlane11Platform(266, "EG20 Clench Common Field", 0),
      XPlane11Platform(422, "EG41 Fishburn Airfield", 0),
      XPlane11PlatformNormalLink(219, "EGCB Manchester City Airport and Heliport (Barton)", 32.95m),
      XPlane11Platform(372, "EGCK Caernarfon Airport", 29.95m),
      FsxAndPrepar3dPlatform(49, "EGCW Welshpool Airport", 26.95m),
      XPlane11Platform(256,  "EGFF Cardiff Airport", 34.95m),
      FsxAndPrepar3dPlatform(50,  "EGFF Cardiff Airport", 26.95m),
      XPlane11Platform(289, "EGHA Compton Abbas Airfield", 26.95m),
      FsxAndPrepar3dPlatform(51, "EGHI Southampton Airport", 34.95m),
      XPlane11Platform(252, "EGHI Southampton Airport", 34.95m),
      FsxAndPrepar3dPlatform(52, "EGHP Popham Airfield", 26.95m),
      XPlane11Platform(268, "EGHP Popham Airfield", 26.95m),
      FsxAndPrepar3dPlatform(53, "EGHR Chichester / Goodwood Airport", 34.95m),
      XPlane11Platform(257, "EGHR Chichester / Goodwood Airport", 34.95m),
      FsxAndPrepar3dPlatform(245, "EGJA Alderney Airport", 14.95m),
      FsxAndPrepar3dPlatform(54, "EGKA Shoreham (Brighton) Airport", 26.95m),
      XPlane11Platform(254, "EGKA Shoreham (Brighton) Airport", 26.95m),
      Prepar3Dv4Platform(295, "EGLC London City Airport", 32.95m)
    };

    return products;
  }

  public static Product FsxAndPrepar3dPlatform(int id, string name, decimal currentPrice = 0m)
  {
    var product = new Product
    {
      Id = id,
      Icao = GetIcao(name),
      Name = name,
      Airport = GetAirport(name),
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
      Icao = GetIcao(name),
      Name = name,
      Airport = GetAirport(name),
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

  public static Product Prepar3Dv4Platform(int id, string name, decimal currentPrice = 0m)
  {
    var product = new Product
    {
      Id = id,
      Icao = GetIcao(name),
      Name = name,
      Airport = GetAirport(name),
      Platform = Prepar3Dv4,
      CurrentPrice = currentPrice,
      Link = GetLink(name),
      Simulators = new List<string>() {
        P3dv4
      }
    };

    return product;
  }

  public static Product Prepar3Dv4Platform_3_4(int id, string name, decimal currentPrice = 0m)
  {
    var product = new Product
    {
      Id = id,
      Icao = GetIcao(name),
      Name = name,
      Airport = GetAirport(name),
      Platform = Prepar3Dv4,
      CurrentPrice = currentPrice,
      Link = GetLink(name),
      Simulators = new List<string>() {
        P3dv3, P3dv4
      }
    };

    return product;
  }

  public static Product Prepar3Dv5Platform(int id, string name, decimal currentPrice, string icao = null)
  {
    var product = new Product
    {
      Id = id,
      Icao = string.IsNullOrEmpty(icao)
        ? GetIcao(name)
        : icao,
      Name = name,
      Airport = GetAirport(name),
      Platform = Prepar3Dv5,
      CurrentPrice = currentPrice,
      Link = string.IsNullOrEmpty(icao)
      ? GetLinkMsfs(name)
      : GetLinkWithIcao(icao),
      Simulators = new List<string> {
        P3dv5
      }
    };

    return product;
  }

  public static Product Prepar3Dv4Pluslatform(int id, string name, decimal currentPrice, string icao = null)
  {
    var product = new Product
    {
      Id = id,
      Icao = string.IsNullOrEmpty(icao)
        ? GetIcao(name)
        : icao,
      Name = name,
      Airport = GetAirport(name),
      Platform = Prepar3Dv5,
      CurrentPrice = currentPrice,
      Link = string.IsNullOrEmpty(icao)
      ? GetLinkMsfs(name)
      : GetLinkWithIcao(icao),
      Simulators = new List<string> {
        P3dv4, P3dv5
      }
    };

    return product;
  }

  public static Product MsFlightSimulatorPlatform(int id, string name, decimal currentPrice, string icao = null)
  {
    var product = new Product
    {
      Id = id,
      Icao = string.IsNullOrEmpty(icao)
        ? GetIcao(name)
        : icao,
      Name = name,
      Airport = GetAirport(name),
      Platform = MsFlightSimulator,
      CurrentPrice = currentPrice,
      Link = string.IsNullOrEmpty(icao)
      ? GetLinkMsfs(name)
      : GetLinkMsfsWithIcao(icao),
      Simulators = new List<string> {
        Msfs
      }
    };

    return product;
  }

  public static Product XPlane11Platform(int id, string name, decimal currentPrice, string icao = null)
  {
    var product = new Product
    {
      Id = id,
      Icao = string.IsNullOrEmpty(icao)
        ? GetIcao(name)
        : icao,
      Name = name,
      Airport = GetAirport(name),
      Platform = XPlane11,
      CurrentPrice = currentPrice,
      Link = string.IsNullOrEmpty(icao)
      ? GetLinkXp11(name)
      : GetLinkXp11WithIcao(icao),
      Simulators = new List<string> {
        Xp11
      }
    };

    return product;
  }

  public static Product XPlane11PlatformNormalLink(int id, string name, decimal currentPrice)
  {
    var product = new Product
    {
      Id = id,
      Icao = GetIcao(name),
      Name = name,
      Airport = GetAirport(name),
      Platform = XPlane11,
      CurrentPrice = currentPrice,
      Link = GetLink(name),
      Simulators = new List<string> {
        Xp11
      }
    };

    return product;
  }
}
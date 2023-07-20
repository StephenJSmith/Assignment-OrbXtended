export interface IProduct {
  id: number;
  icao: string;
  name: string;
  airport: string;
  platform: string;
  currentPrice: number;
  link: string;
  simulators: string[];
}

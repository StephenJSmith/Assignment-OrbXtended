import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct } from '../models/product';
import { environment } from '../../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getProducts(
    simulator: string, 
    sortField: string, 
    sortOrder: string): Observable<IProduct[]> {
      const url = `${this.baseUrl}/products/top/${simulator}`;
      // TODO: Include sortField and sortOrder parameters as query params
      
      return this.http.get<IProduct[]>(url);
  };

  getSimulators(): Observable<string[]> {
    const url = `${this.baseUrl}/products/simulators`;

    return this.http.get<string[]>(url);
  }
}

import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct } from '../models/product';
import { environment } from '../../../environments/environment.development';
import { IProductsSettings } from '../models/products-settings';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getProductsSettings(): Observable<IProductsSettings> {
    const url = `${this.baseUrl}/products/settings`;

    return this.http.get<IProductsSettings>(url);
  }

  getTopProducts(
    simulator: string, 
    sortField: string, 
    sortOrder: string
  ): Observable<IProduct[]> {
      const url = `${this.baseUrl}/products/top/${simulator}`;
      
    return this.http.get<IProduct[]>(url);
  };

  getPagedProducts(
    simulator: string, 
    sortField: string, 
    sortOrder: string,
    skip: number,
    take: number
  ): Observable<IProduct[]> {
    const url = `${this.baseUrl}/products/page/${simulator}`;
    let params = new HttpParams();
    params = params.append('sort', sortField);
    params = params.append('order', sortOrder);
    params = params.append('skip', skip.toString());
    params = params.append('take', take.toString());

    return this.http.get<IProduct[]>(url, {params});
  }

  getSimulators(): Observable<string[]> {
    const url = `${this.baseUrl}/products/simulators`;

    return this.http.get<string[]>(url);
  }
}

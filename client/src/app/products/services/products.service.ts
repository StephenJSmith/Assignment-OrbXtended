import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct } from '../models/product';
import { environment } from '../../../environments/environment.development';
import { IPagination } from '../models/pagination';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  public pagination: IPagination | null = null;

  private baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  initialiseProductsPagination(): void {
    const url = `${this.baseUrl}/products/initial`;

    this.http.get<IPagination>(url)
      .subscribe(response => this.pagination = {
        sortableFields: response.sortableFields,
        order: response.order,
        skip: response.skip,
        take: response.take
      });
  }

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

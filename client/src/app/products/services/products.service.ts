import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IProduct } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http: HttpClient) { 

  }

  getProductsList(
    simulator: string, 
    sortField: string, 
    sortOrder: string): Observable<IProduct[]> {
      const url = `http://localhost:5000/api/products/top/${simulator}`;
      // TODO: Include sortField and sortOrder parameters as query params
      
      return this.http.get<IProduct[]>(url);
  };
}

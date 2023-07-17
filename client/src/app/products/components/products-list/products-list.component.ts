import { Component, OnDestroy, OnInit } from '@angular/core';
import { ProductsService } from '../../services/products.service';
import { Subscription } from 'rxjs';
import { IProduct } from '../../models/product';
import { IPagination } from '../../models/pagination';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})
export class ProductsListComponent implements OnInit, OnDestroy {
  private subscriptions: Subscription[] = [];
  simulator: string = '';
  private sortField: string = 'currentPrice';
  private sortOrder: string = 'desc';
  products: IProduct[] = [];
  simulators: string[] = [];
  pagination: IPagination | null = null;

  constructor(private productService: ProductsService) {}

  ngOnInit(): void {
    this.subscriptions.push(
      this.productService
        .getSimulators()
        .subscribe((simulators: string[]) =>{ 
          this.simulators = simulators;
          this.pagination = this.productService.pagination;
        })
    );
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(s => s.unsubscribe());
  }

  onSearch(): void {
    if (!this.simulator) {
      this.products = [];

      return;
    };

    this.subscriptions.push(
      this.productService
        .getProducts(this.simulator, this.sortField, this.sortOrder)
        .subscribe((products: IProduct[]) => this.products = products)
      );
  }
}

import { Component, OnDestroy, OnInit } from '@angular/core';
import { ProductsService } from '../../services/products.service';
import { Subscription } from 'rxjs';
import { IProduct } from '../../models/product';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.scss']
})
export class ProductsListComponent implements OnInit, OnDestroy {
  private subscription: Subscription |null = null;
  simulator: string = '';
  private sortField: string = 'currentPrice';
  private sortOrder: string = 'desc';
  products: IProduct[] = [];

  constructor(private productService: ProductsService) {}

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

  onSearch(): void {
    if (!this.simulator) {
      this.products = [];

      return;
    };

    this.subscription = this.productService
      .getProductsList(this.simulator, this.sortField, this.sortOrder)
      .subscribe((products: IProduct[]) => this.products = products);
  }

  spaceProductSimulators(simulators: string[]): string {
    return simulators.join(', ');
  }
}

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
  sortField: string | undefined = 'CurrentPrice';
  sortOrder: string = 'Desc';
  skip: number = 0;
  take: number = 0;
  products: IProduct[] = [];
  simulators: string[] = [];
  pagination: IPagination | null = null;

  get canDisablePrevPage(): boolean {
    return this.skip === 0;
  }

  constructor(private productService: ProductsService) {}

  ngOnInit(): void {
    this.subscriptions.push(
      this.productService
        .getSimulators()
        .subscribe((simulators: string[]) =>{ 
          this.simulators = simulators;
          this.pagination = this.productService.pagination;
          this.sortField = this.pagination?.sortableFields.find(x => x.isSortField)?.field;
          this.sortOrder = this.pagination?.order!;
          this.skip = this.pagination?.skip!;
          this.take = this.pagination?.take!;
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
        .getProducts(this.simulator, this.sortField!, this.sortOrder)
        .subscribe((products: IProduct[]) => this.products = products)
      );
  }

  onPrevPage() {
    this.skip = Math.max(this.skip - this.take, 0);
  }

  onNextPage() {
    this.skip += this.take;
  }
}

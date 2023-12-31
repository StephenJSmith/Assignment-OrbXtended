import { Component, OnDestroy, OnInit } from '@angular/core';
import { ProductsService } from '../../services/products.service';
import { Subscription } from 'rxjs';
import { IProduct } from '../../models/product';
import { IProductsSettings } from '../../models/products-settings';

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
  settings: IProductsSettings | null = null;
  canShowSelections: boolean = false;

  get pageNumber(): number {
    return Math.floor(this.skip / this.take) + 1;
  }

  get canDisableFirstPage(): boolean {
    return this.skip <= 0;
  }

  get canDisablePrevPage(): boolean {
    return this.skip <= 0;
  }

  get canDisableSearch(): boolean {
    return !this.simulator;
  }

  constructor(private productService: ProductsService) {}

  ngOnInit(): void {
    this.subscriptions.push(
      this.productService
        .getProductsSettings()
        .subscribe((settings: IProductsSettings) => {
          this.settings = settings;
          this.sortField = this.settings?.sortableFields.find(x => x.isSortField)?.field;
          this.sortOrder = this.settings?.order!;
          this.skip = this.settings?.skip!;
          this.take = this.settings?.take!;
          this.canShowSelections = true;
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
        .getPagedProducts(
          this.simulator, 
          this.sortField!, 
          this.sortOrder,
          this.skip,
          this.take)
        .subscribe((products: IProduct[]) => this.products = products)
      );
  }

  onFirstPage() {
    this.skip = 0;
  }

  onPrevPage() {
    this.skip = Math.max(this.skip - this.take, 0);
  }

  onNextPage() {
    this.skip += this.take;
  }

  onChangePageSize() {
    this.skip = 0;

    if (this.take > this.settings?.maxTake!) {
      this.take = this.settings?.maxTake!;
    }
  }
}

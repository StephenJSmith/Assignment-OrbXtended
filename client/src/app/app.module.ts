import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ProductsListComponent } from './products/components/products-list/products-list.component';
import { FormsModule } from '@angular/forms';
import { CsvSpacerPipe } from './shared/pipes/csv-spacer.pipe';

@NgModule({
  declarations: [
    AppComponent,
    ProductsListComponent,
    CsvSpacerPipe
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

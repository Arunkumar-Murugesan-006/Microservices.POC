import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './components/products/product/product.component';
import { ProductListComponent } from './components/products/product-list/product-list.component';
import { QuoteComponent } from './components/quotes/quote/quote.component';
import { QuoteListComponent } from './components/quotes/quote-list/quote-list.component';

const routes: Routes = 
[
  { path: "", component: ProductListComponent },
  { path: "product", component: ProductComponent },
  { path: "quote", component: QuoteComponent },
  { path: "product-list", component: ProductListComponent },
  { path: "quote-list", component: QuoteListComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

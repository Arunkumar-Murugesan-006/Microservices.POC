import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductComponent } from './components/products/product/product.component';
import { ProductListComponent } from './components/products/product-list/product-list.component';
import { QuoteComponent } from './components/quotes/quote/quote.component';
import { QuoteListComponent } from './components/quotes/quote-list/quote-list.component';
import { ProductService } from './services/product/product.service';
import { QuoteService } from './services/quote/quote.service';
import { NotificationService } from './services/notification/notification.service';


@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ProductComponent,
    QuoteListComponent,
    QuoteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ProductService, QuoteService, NotificationService],
  bootstrap: [AppComponent],
  entryComponents: [ProductComponent]
})
export class AppModule { }

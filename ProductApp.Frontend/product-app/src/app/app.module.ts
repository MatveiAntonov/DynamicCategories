import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductCategoriesComponent } from './pages/product-categories/product-categories.component';
import { NavigationComponent } from './pages/navigation/navigation.component';
import { CreateProductComponent } from './pages/create-product/create-product.component';
import { AllProductsComponent } from './pages/all-products/all-products.component';
import { CategoryComponent } from './components/category/category.component';
import { AddingCategoryComponent } from './components/adding-category/adding-category.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductCategoriesComponent,
    NavigationComponent,
    CreateProductComponent,
    AllProductsComponent,
    CategoryComponent,
    AddingCategoryComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

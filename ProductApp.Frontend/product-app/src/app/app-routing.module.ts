import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { ProductCategoriesComponent } from './pages/product-categories/product-categories.component';
import { CreateProductComponent } from './pages/create-product/create-product.component';
import { AllProductsComponent } from './pages/all-products/all-products.component';


const routes: Routes = [
  { path: 'categories', component: ProductCategoriesComponent },
  { path: 'create', component: CreateProductComponent },
  { path: 'all', component: AllProductsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

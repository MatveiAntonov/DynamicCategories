import { Component, OnInit } from '@angular/core';
import { ICategory } from 'src/app/models/category';
import { CategoriesService } from 'src/app/services/categories.service';

@Component({
  selector: 'app-product-categories',
  templateUrl: './product-categories.component.html'
})
export class ProductCategoriesComponent implements OnInit{
  categories : ICategory[] = [];
  addCategory = false;

  constructor(private categoriesService : CategoriesService) {
  }

  ngOnInit(): void {
   this.categoriesService.getAllCategories().subscribe(categories => {
    this.categories = categories;
    
   });
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { ICategory } from '../models/category';

@Injectable({
  providedIn: 'root'
})

export class CategoriesService {
  constructor(private http: HttpClient) {
  }

  getAllCategories(): Observable<ICategory[]> {
    return this.http.get<ICategory[]>('https://localhost:9001/categories/all');
  }
}
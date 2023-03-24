import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'adding-category',
  templateUrl: './adding-category.component.html'
})

export class AddingCategoryComponent {
  @Output() onChanged = new EventEmitter();

  name        : string = "";
  description : string = "";
  title       : string = "";


  cancel() {
    this.onChanged.emit();
  }

  addCategory() {
    console.log(this.name);
    console.log(this.description);
    console.log(this.title);
  }
}
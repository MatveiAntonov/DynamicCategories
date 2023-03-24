import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html'
})

export class CategoryComponent {
  @Input() id?          : number = undefined;
  @Input() name        : string = "";
  @Input() description : string = "";
}
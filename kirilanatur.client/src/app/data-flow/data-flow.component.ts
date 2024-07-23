import { Component } from '@angular/core';
import { FormControl, FormGroup } from "@angular/forms";

@Component({
  selector: 'app-data-flow',
  templateUrl: './data-flow.component.html',
  styleUrl: './data-flow.component.css'
})
export class DataFlowComponent {

  product = new FormGroup({
    name: new FormControl(''),
    description: new FormControl(''),
  });

  async addUserHandler(): Promise<void> {
    alert('Product ' + this.product.value.name + ' added.')
    this.product.reset();
  }

}

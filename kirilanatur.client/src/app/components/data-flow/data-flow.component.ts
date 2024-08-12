import { Component } from '@angular/core';
import { FormControl, FormGroup } from "@angular/forms";
import { Product, UserService } from "../../services/user/user.service";

@Component({
  selector: 'app-data-flow',
  templateUrl: './data-flow.component.html',
  styleUrl: './data-flow.component.css'
})
export class DataFlowComponent {

  products: any = [];

  userForm = new FormGroup({
    name: new FormControl(''),
    description: new FormControl(''),
  });

  constructor(private userService: UserService) {}

  async addUserHandler(): Promise<void> {
    const product: Product = {
      name: this.userForm.value.name as string,
      description: this.userForm.value.description as string,
    };

    this.userService.addUser(product).subscribe({
      next: (response: any) => {
        alert(response.message);
        this.userForm.reset();
      },
      error: (error: any) => {
        console.error('Error adding product: ', error);
      }
    });

    this.userForm.reset();
  }

  async getUsersHandler(): Promise<void> {
    alert("Getting users...")
    this.userService.getUsers().subscribe({
      next: (response: any) => {
        this.products = response;
      },
      error: (error: any) => {
        console.error('Error getting products: ', error)
      }
    });
  }

}

import { Component } from '@angular/core';
import { FormControl, FormGroup } from "@angular/forms";
import { TmpProduct, UserService } from "../../services/user/user.service";

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
    const product: TmpProduct = {
      name: this.userForm.value.name as string,
      description: this.userForm.value.description as string,
    };

    //await this.userService.addUser(product);
    this.userForm.reset();
  }

  async getUsersHandler(): Promise<void> {
    //this.products = await this.userService.getUsers();
  }

}

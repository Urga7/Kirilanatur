import { Component } from '@angular/core';
import { FormControl, FormGroup } from "@angular/forms";
import { User, UserService } from "../../services/user/user.service";

@Component({
  selector: 'app-data-flow',
  templateUrl: './data-flow.component.html',
  styleUrl: './data-flow.component.css'
})
export class DataFlowComponent {

  userForm = new FormGroup({
    name: new FormControl(''),
    surname: new FormControl(''),
  });

  constructor(private userService: UserService) {}

  async addUserHandler(): Promise<void> {
    const user: User = {
      name: this.userForm.value.name as string,
      surname: this.userForm.value.surname as string,
    };

    this.userService.addUser(user).subscribe({
      next: (response: any) => {
        alert(response.message);
        this.userForm.reset();
      },
      error: (error: any) => {
        console.error('Error adding user:', error);
      }
    });

    this.userForm.reset();
  }

}

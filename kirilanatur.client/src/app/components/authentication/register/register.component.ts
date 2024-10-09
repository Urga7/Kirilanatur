import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { RegistrationForm } from "../../../models/forms.model";
import { ControllerFunction, RequestMethodType, ServerService } from "../../../services/server/server.service";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  registrationForm = new FormGroup({
    name: new FormControl(''),
    surname: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(private serverService: ServerService) { }

  ngOnInit() {

  }

  async onSubmit() {
    const form: RegistrationForm = {
      Name: this.registrationForm.value.name ?? "",
      Surname: this.registrationForm.value.surname ?? "",
      Email: this.registrationForm.value.email ?? "",
      Password: this.registrationForm.value.password ?? "",
    };

    const response = await this.serverService.ExecuteServerFunction(ControllerFunction.RegisterUser, form, RequestMethodType.POST);
    console.log(response);
  }
}

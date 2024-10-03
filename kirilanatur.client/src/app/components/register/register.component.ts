import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { RegistrationForm } from "../../models/RegistrationForm.model";
import { ControllerFunction, RequestMethodType, ServerService } from "../../services/server/server.service";

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
        name: this.registrationForm.value.name ?? "",
        surname: this.registrationForm.value.surname ?? "",
        email: this.registrationForm.value.email ?? "",
        password: this.registrationForm.value.password ?? "",
      };

      const response = await this.serverService.ExecuteServerFunction(ControllerFunction.RegisterUser, form, RequestMethodType.POST);
      console.log(response);
    }
  }

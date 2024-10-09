import { Component } from '@angular/core';
import { ControllerFunction, RequestMethodType, ServerService } from "../../../services/server/server.service";
import { LoginForm } from "../../../models/forms.model";
import { FormControl, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs/internal/lastValueFrom';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(private serverService: ServerService, private httpClient: HttpClient) { }

  async onSubmit() {
    const form: LoginForm = {
      email: this.loginForm.value.username ?? "",
      password: this.loginForm.value.password ?? "",
    };

    const response$ = this.httpClient.post('https://localhost:44387/login', form);
    const response = await lastValueFrom(response$);
    console.log(response);
  }
}

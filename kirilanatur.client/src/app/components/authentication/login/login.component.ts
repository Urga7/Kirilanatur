import { Component } from '@angular/core';
import { ControllerFunction, RequestMethodType, ServerService } from "../../../services/server/server.service";
import { LoginForm } from "../../../models/forms.model";
import { FormControl, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs/internal/lastValueFrom';
import { Observable } from 'rxjs';
import { AuthenticationService } from "../../../services/authentication/authentication.service";
import { TokensDto } from "../../../models/authentication-dtos";

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

  constructor(
    private httpClient: HttpClient,
    private authService: AuthenticationService
  ) { }

  async onSubmit(): Promise<void> {
    const form: LoginForm = {
      email: this.loginForm.value.username ?? "",
      password: this.loginForm.value.password ?? "",
    };

    const response$: Observable<TokensDto> = this.httpClient.post<TokensDto>('https://localhost:44387/login', form);
    const response: TokensDto = await lastValueFrom(response$);
    this.authService.setTokens(response.accessToken, response.refreshToken);
  }
}

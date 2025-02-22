import { Component } from '@angular/core';
import { LoginForm } from "../../../models/forms.model";
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs/internal/lastValueFrom';
import { Observable } from 'rxjs';
import { AuthenticationService } from "../../../services/authentication.service";
import { TokensDto } from "../../../models/authentication-dtos";

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrl: './login.component.css',
    standalone: true,
    imports: [ReactiveFormsModule]
})
export class LoginComponent {
  private loginUrl: string = 'https://localhost:44387/login';

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

    const response$: Observable<TokensDto> = this.httpClient.post<TokensDto>(this.loginUrl, form);
    const response: TokensDto = await lastValueFrom(response$);
    this.authService.setTokens(response.accessToken, response.refreshToken);
  }
}

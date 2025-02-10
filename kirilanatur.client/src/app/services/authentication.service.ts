import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private readonly TOKEN_KEY: string = 'bearerToken';
  private readonly REFRESH_TOKEN_KEY: string = 'refreshToken';

  setTokens(bearerToken: string, refreshToken: string): void {
    localStorage.setItem(this.TOKEN_KEY, bearerToken);
    localStorage.setItem(this.REFRESH_TOKEN_KEY, refreshToken);
  }

  getBearerToken(): string {
    return localStorage.getItem(this.TOKEN_KEY) ?? "";
  }

  clearTokens(): void {
    localStorage.removeItem(this.TOKEN_KEY);
    localStorage.removeItem(this.REFRESH_TOKEN_KEY);
  }
}

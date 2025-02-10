import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from "./authentication.service";

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor {
  constructor(private authService: AuthenticationService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const bearerToken: string = this.authService.getBearerToken();
    if (bearerToken) {
      const clonedReq: HttpRequest<any> = req.clone({
        setHeaders: {
          Authorization: `Bearer ${bearerToken}`
        }
      });

      return next.handle(clonedReq);
    }

    return next.handle(req);
  }
}


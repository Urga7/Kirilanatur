import { importProvidersFrom } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { ReactiveFormsModule } from "@angular/forms";
import { NgOptimizedImage } from "@angular/common";
import { TranslateLoader, TranslateModule } from "@ngx-translate/core";
import { createTranslateLoader } from "./utils/translate-loader";
import { HTTP_INTERCEPTORS, HttpClient, provideHttpClient, withInterceptorsFromDi } from "@angular/common/http";
import { AuthInterceptorService } from "./services/auth-interceptor.service";
import { provideRouter } from "@angular/router";
import { routes } from "./app.routes";

export const appConfig = {
  providers: [
    importProvidersFrom(BrowserModule, ReactiveFormsModule, NgOptimizedImage, TranslateModule.forRoot({
      defaultLanguage: 'sl',
      useDefaultLang: true,
      loader: {
        provide: TranslateLoader,
        useFactory: createTranslateLoader,
        deps: [HttpClient]
      }
    })),
    provideRouter(routes),
    provideHttpClient(withInterceptorsFromDi()),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true,
    }
  ]
}

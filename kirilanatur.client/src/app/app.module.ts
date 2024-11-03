import { HTTP_INTERCEPTORS, HttpClient, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { DataFlowComponent } from './components/data-flow/data-flow.component';
import { ReactiveFormsModule } from "@angular/forms";
import { TranslateLoader, TranslateModule } from "@ngx-translate/core";
import { createTranslateLoader } from "./utils/translate-loader";
import { NgOptimizedImage } from "@angular/common";
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HomeComponent } from './components/home/home.component';
import { SandalsComponent } from './components/sandals/sandals.component';
import { AdminComponent } from './components/admin/admin.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { LoginComponent } from './components/authentication/login/login.component';
import { AuthInterceptorService } from "./services/interceptors/auth-interceptor/auth-interceptor.service";

@NgModule({
  declarations: [
    AppComponent,
    DataFlowComponent,
    NavbarComponent,
    HomeComponent,
    SandalsComponent,
    AdminComponent,
    RegisterComponent,
    LoginComponent,
  ],
  bootstrap: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    NgOptimizedImage,
    TranslateModule.forRoot({
      defaultLanguage: 'sl',
      useDefaultLang: true,
      loader: {
        provide: TranslateLoader,
        useFactory: createTranslateLoader,
        deps: [HttpClient]
      }
    })
  ],
  providers: [
    provideHttpClient(withInterceptorsFromDi()),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true,
    },
  ]
})

export class AppModule { }

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NavbarComponent } from './components/navbar/navbar.component';
import { RouterOutlet } from '@angular/router';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    standalone: true,
    imports: [NavbarComponent, RouterOutlet]
})
export class AppComponent implements OnInit {

  constructor(private http: HttpClient) {}

  ngOnInit() {

  }

}

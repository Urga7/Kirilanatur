import { Component } from '@angular/core';
import { ShopPreviewComponent } from "../shop-preview/shop-preview.component";
import { FooterComponent } from "../footer/footer.component";
import {NavbarComponent} from "../navbar/navbar.component";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  imports: [
    ShopPreviewComponent,
    FooterComponent,
    NavbarComponent
  ],
  standalone: true
})
export class HomeComponent {

}

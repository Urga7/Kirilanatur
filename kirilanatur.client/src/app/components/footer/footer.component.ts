import { Component } from '@angular/core';
import {SocialMediaLinksComponent} from "../social-media-links/social-media-links.component";

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [
    SocialMediaLinksComponent
  ],
  templateUrl: './footer.component.html',
  styleUrl: './footer.component.css'
})
export class FooterComponent {

}

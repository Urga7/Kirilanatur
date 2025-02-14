import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { LanguageSelectionComponent } from "../language-selection/language-selection.component";
import { SocialMediaLinksComponent } from "../social-media-links/social-media-links.component";

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrl: './navbar.component.css',
    standalone: true,
  imports: [
    RouterLink,
    RouterLinkActive,
    LanguageSelectionComponent,
    TranslateModule,
    SocialMediaLinksComponent,
  ]
})
export class NavbarComponent {

}

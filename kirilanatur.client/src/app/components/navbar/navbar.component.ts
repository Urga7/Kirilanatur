import { Component } from '@angular/core';
import { TranslationService } from "../../services/translation.service";
import { RouterLink, RouterLinkActive } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrl: './navbar.component.css',
    standalone: true,
    imports: [RouterLink, RouterLinkActive, TranslateModule]
})
export class NavbarComponent {

  constructor(private translationService : TranslationService) {}

  switchLanguage(lang: string): void {
    this.translationService.switchLanguage(lang);
  }

}

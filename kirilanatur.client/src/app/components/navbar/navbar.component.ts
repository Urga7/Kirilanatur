import { Component } from '@angular/core';
import { TranslationService } from "../../services/translation/translation.service";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {

  constructor(private translationService : TranslationService) {}

  switchLanguage(lang: string): void {
    this.translationService.switchLanguage(lang);
  }

}

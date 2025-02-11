import { Component } from '@angular/core';
import { TranslationService } from "../../services/translation.service";

@Component({
  selector: 'app-language-selection',
  standalone: true,
  imports: [],
  templateUrl: './language-selection.component.html',
  styleUrl: './language-selection.component.css'
})
export class LanguageSelectionComponent {
  constructor(private translationService : TranslationService) {}

  switchLanguage(lang: string): void {
    this.translationService.switchLanguage(lang);
  }
}

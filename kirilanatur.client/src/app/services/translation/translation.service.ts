import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class TranslationService {

  constructor(private translateService: TranslateService) { }

  switchLanguage(language: string): void {
    if(language === this.translateService.currentLang)
      return;

    this.translateService.use(language);
  }


}

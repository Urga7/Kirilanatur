import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TranslationService {

  private languageChangeSubject = new BehaviorSubject<string>(this.translateService.currentLang);
  public languageChange$ = this.languageChangeSubject.asObservable();

  constructor(private translateService: TranslateService) { }

  switchLanguage(language: string): void {
    if (language === this.translateService.currentLang)
      return;

    this.translateService.use(language);
    this.languageChangeSubject.next(language);
  }

}

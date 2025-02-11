import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { LanguageSelectionComponent } from "../choose-language/language-selection.component";
import { TranslateModule } from '@ngx-translate/core';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrl: './navbar.component.css',
    standalone: true,
    imports: [
      RouterLink,
      RouterLinkActive,
      LanguageSelectionComponent,
      TranslateModule
    ]
})
export class NavbarComponent {

}

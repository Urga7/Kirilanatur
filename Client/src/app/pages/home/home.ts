import { Component } from '@angular/core';
import {SocialMediaLinks} from '../common/social-media-links/social-media-links';

@Component({
  selector: 'app-home',
  imports: [
    SocialMediaLinks
  ],
  templateUrl: './home.html',
})
export class Home {

}

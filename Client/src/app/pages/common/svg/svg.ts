import { Component, input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-svg',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './svg.html',
})
export class Svg {
  readonly url = input.required<string>();
}

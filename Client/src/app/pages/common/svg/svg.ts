import { Component, effect, inject, input, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-svg',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './svg.html',
})
export class Svg {
  private http = inject(HttpClient);
  readonly url = input.required<string>();
  protected readonly svgContent = signal<string>('');

  constructor() {
    effect(() => {
      const path = this.url();
      if (!path) return;

      this.http.get(path, { responseType: 'text' }).subscribe({
        next: content => this.svgContent.set(content),
        error: err => {
          console.error(`SVG loading failed for ${path}`, err);
          this.svgContent.set('<svg><!-- error loading SVG --></svg>');
        },
      });
    });
  }
}

import { AfterViewInit, Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[AutoFocus]',
  standalone: true
})
export class AutoFocusDirective implements AfterViewInit {

  constructor(private element: ElementRef<HTMLInputElement>) { }
 
  ngAfterViewInit(): void {
    setTimeout(() => {
      this.element.nativeElement.focus();
    }, 0);
  }

}

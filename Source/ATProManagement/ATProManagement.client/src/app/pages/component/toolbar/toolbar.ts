import { Component,Input  } from '@angular/core';

@Component({
  selector: 'app-toolbar',
  standalone: true,
  templateUrl: './toolbar.html',
  styleUrl: './toolbar.css',
})
export class Toolbar {
  @Input()title: string = '';

  @Input() refreshAction?: () => void;

  @Input() addAction?: () => void;

  
}

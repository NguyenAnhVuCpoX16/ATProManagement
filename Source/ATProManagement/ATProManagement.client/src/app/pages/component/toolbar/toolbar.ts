import { Component,Input  } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import { MatDividerModule } from '@angular/material/divider';
import { MatMenuModule } from '@angular/material/menu';

@Component({
  selector: 'app-toolbar',
  standalone: true,
  templateUrl: './toolbar.html',
  styleUrl: './toolbar.css',
  imports: [MatToolbarModule, MatButtonModule, MatIconModule, MatDividerModule,MatMenuModule]
})
export class Toolbar {
  @Input()title: string = '';

  @Input() refreshAction?: () => void;

  @Input() addAction?: () => void;

  
}

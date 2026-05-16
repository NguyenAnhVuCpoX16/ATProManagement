import { Component } from '@angular/core';
import { RouterOutlet} from '@angular/router';

@Component({
  selector: 'app-admin',
  standalone: true,
  templateUrl: './MainLayout.html',
  styleUrl: './MainLayout.css',
  imports: [RouterOutlet],
})
export class Admin {}

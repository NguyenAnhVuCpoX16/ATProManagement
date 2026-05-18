import { Component } from '@angular/core';
import { RouterOutlet} from '@angular/router';
import { Sidebar } from '../../component/sidebar/sidebar';
import { Navbar } from '../../component/navbar/navbar';
import { ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-admin',
  standalone: true,
  templateUrl: './MainLayout.html',
  styleUrl: './MainLayout.css',
  imports: [RouterOutlet,Sidebar,Navbar],
  encapsulation: ViewEncapsulation.None
})
export class Admin {}

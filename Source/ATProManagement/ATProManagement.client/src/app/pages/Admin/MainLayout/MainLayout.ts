import { Component, AfterViewInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Sidebar } from '../../component/sidebar/sidebar';
import { Navbar } from '../../component/navbar/navbar';
import { ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-admin',
  standalone: true,
  templateUrl: './MainLayout.html',
  styleUrl: './MainLayout.css',
  imports: [RouterOutlet, Sidebar, Navbar],
  encapsulation: ViewEncapsulation.None,
})
export class Admin implements AfterViewInit {
  ngAfterViewInit() {
    const el = document.querySelector('[data-toggle="minimize"]');

    el?.addEventListener('click', () => {
      console.log('clicked');

      const body = document.body;

      const hasToggleDisplay = body.classList.contains('sidebar-toggle-display');
      const hasSidebarAbsolute = body.classList.contains('sidebar-absolute');

      if (hasToggleDisplay || hasSidebarAbsolute) {
        body.classList.toggle('sidebar-hidden');
      } else {
        body.classList.toggle('sidebar-icon-only');
      }
    });
  }
}

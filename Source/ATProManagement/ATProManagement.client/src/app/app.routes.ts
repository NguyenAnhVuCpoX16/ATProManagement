import { Routes } from '@angular/router';
import { App } from './app';
import { Admin } from './pages/Admin/MainLayout/MainLayout';
import { Dashboard } from './pages/Admin/page/dashboard/dashboard';
import { Client } from './pages/Admin/page/client/client';

export const routes: Routes = [
  { path: '', component: App },
  {
    path: 'admin',
    component: Admin,
    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
      },
      {
        path: 'dashboard',
        component: Dashboard,
      },
        {
        path: 'Client',
        component: Client,
      },
    ],
  },
];

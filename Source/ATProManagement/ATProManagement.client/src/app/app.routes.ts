import { Routes } from '@angular/router';
import { App } from './app';
import { Admin } from './pages/Admin/MainLayout/MainLayout';
import { Dashboard } from './pages/Admin/page/dashboard/dashboard';

export const routes: Routes = [
  { path: '', component: App },
  {
    path: 'admin',
    component: Admin,
    children: [
      {
        path: 'dashboard',
        component: Dashboard
      },
    ],
  },
];

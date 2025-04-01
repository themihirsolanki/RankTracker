import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ApiGuard } from './core/guards/api.guard';

export const routes: Routes = [
    { path: 'connection-error', loadComponent: () => import('./pages/connection-error/connection-error.component').then(m => m.ConnectionErrorComponent) },
    { path: 'setup', loadComponent: () => import('./pages/setup/setup.component').then(m => m.SetupComponent) },
    { path: 'setup-keywords', loadComponent: () => import('./pages/setup/setup-keywords.component').then(m => m.SetupKeywordsComponent) },
    { path: '', component: DashboardComponent, pathMatch: 'full', canActivate: [ApiGuard] },
];

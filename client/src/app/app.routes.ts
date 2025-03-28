import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { ApiGuard } from './core/guards/api.guard';

export const routes: Routes = [
    { path: '', component: DashboardComponent, pathMatch: 'full', canActivate: [ApiGuard] },
    { path: 'connection-error', loadComponent: () => import('./pages/connection-error/connection-error.component').then(m => m.ConnectionErrorComponent) },
];

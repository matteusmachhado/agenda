import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { loginGuard } from './guards/login.guard';
import { LoginComponent } from './pages/login/login.component';

export const routes: Routes = [
    { path: '', component: AppComponent },
    { 
        path: 'login', 
        canActivate: [loginGuard],
        component: LoginComponent
    },
    { 
        path: 'account/profile',
        loadComponent: () => import('./pages/account/profile/profile.component')
            .then(c => c.ProfileComponent)
    },
    { path: '**', component: NotFoundComponent }
];

import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { pageLoginGuard } from './guards/page-login.guard';
import { pageVerifyGuard } from './guards/page-verify.guard';
import { LoginComponent } from './pages/login/login.component';
import { VerifyComponent } from './pages/verify/verify.component';

export const routes: Routes = [
    { path: '', component: AppComponent },
    { path: 'login', component: LoginComponent, canActivate: [pageLoginGuard] },
    { path: 'verify', component: VerifyComponent, canActivate: [pageVerifyGuard] },
    { path: '**', component: NotFoundComponent }
];

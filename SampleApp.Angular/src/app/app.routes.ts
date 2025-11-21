import { Routes } from '@angular/router';
import { Header } from './header/header';
import { UserComponent } from './users/users';
import { HomeComponent } from './home/home.component';
import { Auth } from './auth/auth';
import { Sign } from './sign/sign';

export const routes: Routes = [
    { path: 'header', component: Header },
    { path: 'users', component: UserComponent },
    { path: 'auth', component: Auth},
    { path: 'sign', component: Sign},
    { path: 'home', component: HomeComponent },
    { path: '', component: HomeComponent },
];
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeModule } from './home/home.module';
import { HomeComponent } from './home/home/home.component';

const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent }
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes),
        HomeModule,
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }

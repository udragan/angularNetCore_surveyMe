import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeModule } from './../home/home.module';
import { NavComponent } from './nav/nav.component';

@NgModule({
    imports: [
        CommonModule,
    ],
    declarations: [
        NavComponent
    ],
    exports: [
        NavComponent
    ]
})
export class CoreModule { }

import { NgModule, OnInit } from "@angular/core";
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AirPlaneFormComponent } from './airplane-form/airplane-form.component';

import { AirPlaneListComponent } from './airplane-list/airplane-list.component';
import { AirPlaneFormAlterComponent } from './airplane-form-alter/airplane-form-alter.component';
import { AppRoutingModule } from '../app.routing.module';

@NgModule({
    declarations: [ AirPlaneFormComponent,  AirPlaneListComponent, AirPlaneFormAlterComponent ],
    exports: [ AirPlaneFormComponent, AirPlaneListComponent, AirPlaneFormAlterComponent],
    imports: [ CommonModule, CommonModule, AppRoutingModule, FormsModule, ReactiveFormsModule ]
})
export class AirPlaneModule { }
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AirPlaneListComponent } from './airplane/airplane-list/airplane-list.component';
import { AirPlaneFormComponent } from './airplane/airplane-form/airplane-form.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { AirPlaneFormAlterComponent } from './airplane/airplane-form-alter/airplane-form-alter.component';

const routes: Routes = [
  { path: '', component: AirPlaneListComponent },
  { path: 'airplane', component: AirPlaneListComponent },
  { path: 'airplane/add', component: AirPlaneFormComponent },
  { path: 'airplane/alter/:id', component: AirPlaneFormAlterComponent },
  { path: 'list/:modelName', component: AirPlaneListComponent },
  { path: 'airplane/:id', component: AirPlaneListComponent },
  { path: '**', component: NotFoundComponent },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}

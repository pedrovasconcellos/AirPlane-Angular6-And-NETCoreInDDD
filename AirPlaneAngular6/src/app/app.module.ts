import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AirPlaneModule } from './airplane/airplane.module';
import { AppRoutingModule } from './app.routing.module';
import { ErrorsModule } from './errors/errors.module';
import { HttpClientModule } from '@angular/common/http';
import { AirplaneService } from './airplane/airplane.service'; //servico da aplicacao inteira

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AirPlaneModule, AppRoutingModule, ErrorsModule,HttpClientModule],
  providers:[AirplaneService], //indicando que serve a aplicacao inteira
  bootstrap: [AppComponent]
})
export class AppModule { }

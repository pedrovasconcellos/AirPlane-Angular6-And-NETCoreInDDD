import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AirplaneService } from '../airplane.service';
import { AirPlaneModelModel } from '../AirPlaneModelModel';
import { AirPlaneAddModel } from '../AirPlaneAddModel';


@Component({
  selector: 'app-airplane-form',
  templateUrl: './airplane-form.component.html',
  styleUrls: ['./airplane-form.component.css']
})
export class AirPlaneFormComponent implements OnInit {

  airPlaneModels: AirPlaneModelModel[] = [];

  webAPI = 'https://airplanedemo.azurewebsites.net/v1/AirPlane/';

  airPlane: AirPlaneAddModel;

  constructor(private airPlaneService: AirplaneService, private router: Router) { }

  ngOnInit(): void {
    this.airPlaneService
      .ListAirPlaneModels("")
      .subscribe(
        data => {
          this.airPlaneModels = data;
          console.log(this.airPlaneModels[0].name);
          console.log(this.airPlaneModels)
        },
        err => console.log(err)
      );
  }

  onSubmit(form){ //funcao disparada com submit
    this.airPlane = form.value;//valor do campos do form
    console.log(this.airPlane);
    this.airPlaneService.PostAirPlane(this.airPlane).subscribe(r =>{ //chama sua funcao de post do seu servico  
    this.router.navigateByUrl('/'); // descomente para voltar pra sua home
    return console.log(r) //mostra response, e vc pode abrir modal pop de resposta pro usuario.
   })
  }
}

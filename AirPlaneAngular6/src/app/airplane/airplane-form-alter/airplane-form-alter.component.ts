import { Component, OnInit, Input } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AirplaneService } from '../airplane.service';
import { AirPlaneModelModel } from '../AirPlaneModelModel';
import { AirPlaneAddModel } from '../AirPlaneAddModel';

@Component({
  selector: 'app-airplane-form-alter',
  templateUrl: './airplane-form-alter.component.html',
  styleUrls: ['./airplane-form-alter.component.css']
})
export class AirPlaneFormAlterComponent implements OnInit {
  airPlaneModels: AirPlaneModelModel[] = [];

  airPlane: AirPlaneAddModel;

  webAPI = 'https://airplanedemo.azurewebsites.net/v1/AirPlane/';
  id: string;

  constructor(private airPlaneService: AirplaneService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      // Airplane ID
      this.id = params.id

      // Current airplane
      this.airPlaneService.getAirplane(this.id).subscribe(response => {
        console.log(response);
      })
    })

    this.airPlaneService
      .ListAirPlaneModels("")
      .subscribe(
        data => {
          this.airPlaneModels = data;
          console.log(this.airPlaneModels)
        },
        err => console.log(err)
      );
  }

  onSubmit(form) { //funcao disparada com submit
    this.airPlane = form.value;//valor do campos do form
    console.log(this.airPlane);
    this.airPlaneService.PutAirPlane(this.id, this.airPlane)
      .subscribe(response => { //chama sua funcao de post do seu servico
        this.router.navigateByUrl('/'); //------->  descomente para voltar pra sua home
        return console.log(response) //mostra response, e vc pode abrir modal pop de resposta pro usuario.
      })
  }
}

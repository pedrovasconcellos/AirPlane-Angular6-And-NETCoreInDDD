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
      .ListAirPlaneModels('')
      .subscribe(
        data => {
          this.airPlaneModels = data;
          console.log(this.airPlaneModels[0].name);
          console.log(this.airPlaneModels)
        },
        err => console.log(err)
      );
  }

  onSubmit(form) {
    this.airPlane = form.value;
    console.log(this.airPlane);
    this.airPlaneService.PostAirPlane(this.airPlane).subscribe(r => {
    this.router.navigateByUrl('/');
    return console.log(r);
   });
  }
}

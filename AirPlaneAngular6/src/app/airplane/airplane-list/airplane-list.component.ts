import { Component, OnInit, Input } from '@angular/core';

import { AirPlaneModel } from '../AirPlaneModel';
import { AirplaneService } from '../airplane.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AirPlaneAddModel } from '../AirPlaneAddModel';

@Component({
  selector: 'app-airplane-list',
  templateUrl: './airplane-list.component.html',
  styleUrls: ['./airplane-list.component.css']
})
export class AirPlaneListComponent implements OnInit {
  airPlanes: AirPlaneModel[] = [];

  webAPI = 'https://airplanedemo.azurewebsites.net/v1/AirPlane/';

  @Input() id: string = "";

  @Input() searchValue: string;//aqui é aonde o campo busca usa

  constructor(private airPlaneService: AirplaneService, private activatedRoute: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    const modelName: string = this.activatedRoute.snapshot.params.modelName;

    this.airPlaneService
      .ListAirPlanes(modelName)
      .subscribe(
        data => { this.airPlanes = data; console.log(data) },
        err => console.log(err)
      );
  }

  onUpdateItem(airplane) {
    this.router.navigate(['/', 'airplane', 'alter', airplane.id])
  }

  onDeleteItem(airplane) {
    console.log('Deleting airplane: ', airplane)
  }
}

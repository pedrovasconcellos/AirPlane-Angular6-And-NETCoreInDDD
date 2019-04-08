import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, NgModule } from '@angular/core';

import { AirPlaneModel } from './AirPlaneModel';
import { AirPlaneModelModel } from './AirPlaneModelModel';
import { AirPlaneAddModel } from './AirPlaneAddModel';

const webAPI = 'https://airplanedemo.azurewebsites.net';
const endPointAirPlane = '/v1/AirPlane';
const endPointAirPlaneModel = '/v1/AirPlaneModel';

@Injectable({
  providedIn: 'root',
})
export class AirplaneService {
  constructor(private http: HttpClient) { }

  getAirplane(id: string) 
  {
    const url = `${webAPI}${endPointAirPlane}/${id}`
    return this.http.get(url);
  }

  ListAirPlanes(modelName: string) 
  {
    const url = `${webAPI}${endPointAirPlane}`;

    if (modelName !== '' && typeof modelName !== 'undefined' && modelName !== null)
      return this.http.get<AirPlaneModel[]>(url + '?model=' + modelName);
    else
      return this.http.get<AirPlaneModel[]>(url);
  }

  ListAirPlaneModels(modelName: string) 
  {
    const url = `${webAPI}${endPointAirPlaneModel}`;

    if (modelName !== '' && typeof modelName !== 'undefined' && modelName !== null)
      return this.http.get<AirPlaneModelModel[]>(url + '?name=' + modelName);
    else
      return this.http.get<AirPlaneModelModel[]>(url);
  }

  PostAirPlane(airPlane: AirPlaneAddModel) 
  {
    let options = {
      headers: new HttpHeaders()
        .set("Content-Type", "application/json")
        .set("Accept", "application/json")
    };

    const url = `${webAPI}${endPointAirPlane}`;
    return this.http.post<AirPlaneAddModel>(url, airPlane, options);
  }

  PutAirPlane(id: string, airPlane: AirPlaneAddModel) 
  {
    const params = {
      airPlane
    }

    let options = {
      headers: new HttpHeaders()
        .set("Content-Type", "application/json")
        .set("Accept", "application/json")
    };

    const url = `${webAPI}${endPointAirPlane}/${id}`;
    return this.http.put<AirPlaneAddModel>(url, params, options);
  }

  DeleteAirPlane(id: string) 
  {
    let options = {
      headers: new HttpHeaders()
        .set("Content-Type", "application/json")
        .set("Accept", "application/json")
    };

    const url = `${webAPI}${endPointAirPlane}/${id}`;
    return this.http.delete<string>(url,options);
  }
}

import { AirPlaneModelModel } from './AirPlaneModelModel';

export interface AirPlaneModel
{    
    id: string,
    code: string,
    model: AirPlaneModelModel,
    numberOfPassengers: number,
    creationDate: Date
}
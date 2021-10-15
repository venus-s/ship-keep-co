import { formatDate } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { VoyagePointModel } from '../models/voyage-point.model';

@Injectable({
  providedIn: 'root'
})
export class VoyageService {

  private voyageUrl = environment.API_URL + '/ShipKeepCo/Voyage';
  
  constructor(private http: HttpClient) { }

  public getDepartureVoyagePoints(): Observable<VoyagePointModel[]> {
    return this.http.get<VoyagePointModel[]>(this.voyageUrl).pipe(
      map((points) =>
        points.map((point) => {
          point.date = new Date(point.date);
          return point;
        }))
    );
  }

  public getVoyagePoints(departureDate: Date): Observable<VoyagePointModel[]> {
    let formattedDepartureDate = formatDate(departureDate, 'yyyy-MM-dd', 'en-US');

    return this.http.get<VoyagePointModel[]>(`${this.voyageUrl}/${formattedDepartureDate}`)
  }

  public getArrivalVoyagePoints(voyageId: number, departureDate: Date): Observable<VoyagePointModel[]> {
    let formattedDepartureDate = formatDate(departureDate, 'yyyy-MM-dd', 'en-US');

    return this.http.get<VoyagePointModel[]>(`${this.voyageUrl}/${voyageId}/Arrival/${formattedDepartureDate}`);
  }
}
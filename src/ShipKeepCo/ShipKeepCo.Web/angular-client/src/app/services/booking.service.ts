import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { BookingModel } from '../models/booking.model';
import { CreateBookingModel } from '../models/create-booking.model';
import { PricePerNightModel } from '../models/price-per-night.model';

@Injectable({
  providedIn: 'root'
})
export class BookingService {

  private bookingsUrl = environment.API_URL + '/ShipKeepCo/Booking';
  
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(
    private http: HttpClient
  ) { }

  public getPricePerNight(): Observable<PricePerNightModel> {
    return this.http.get<PricePerNightModel>(this.bookingsUrl + '/Price');
  }

  public createBooking(booking: CreateBookingModel): Observable<BookingModel> {
    return this.http.post<BookingModel>(this.bookingsUrl, booking, this.httpOptions);
  }

  public getBooking(hashId: string | null): Observable<BookingModel> {
    return this.http.get<BookingModel>(`${this.bookingsUrl}/${hashId}`);
  }
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from '@angular/router';
import { PrimeNGConfig } from 'primeng/api';
import { forkJoin as observableForkJoin, Observable } from 'rxjs';

import { BookingModel } from '../models/booking.model';
import { CreateBookingModel } from '../models/create-booking.model';
import { VoyagePointModel } from '../models/voyage-point.model';
import { BookingService } from '../services/booking.service';
import { VoyageService } from '../services/voyage.service';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.scss']
})
export class BookingComponent implements OnInit {

  public loading: boolean = false;
  public submitted: boolean = false;

  public form: FormGroup;
  public pricePerNight: number = 0;

  public voyagePoints: VoyagePointModel[] = [];

  public departureVoyagePoints: VoyagePointModel[] = [];
  public arrivalVoyagePoints: VoyagePointModel[] = [];
  public selectedArrivalVoyagePoint: VoyagePointModel[] = [];

  public minDepartureDate: Date = new Date();
  public minArrivalDate: Date = new Date();

  public disabledDepartureDates: Date[] = [];
  public disabledArrivalDates: Date[] = [];

  constructor(
    private bookingService: BookingService,
    private voyageService: VoyageService,
    private primengConfig: PrimeNGConfig,
    private formBuilder: FormBuilder,
    private router: Router) {
      this.primengConfig.ripple = true;

      this.form = this.formBuilder.group({
        customerFirstName: [null, [Validators.required, this.noWhitespaceValidator]],
        customerLastName: [null, [Validators.required, this.noWhitespaceValidator]],
        departureDate: [null, [Validators.required]],
        departureVoyagePoint: [null, [Validators.required]],
        arrivalDate: [null, [Validators.required]],
        arrivalVoyagePoint: [null, [Validators.required]],
     });}

  public ngOnInit(): void {
    this.initializeForm();
    this.initializeData();
  }

  private initializeForm(): void {
    this.form.controls.departureDate.valueChanges.subscribe(() => this.updateValidVoyagePoints());
    this.form.controls.departureVoyagePoint.valueChanges.subscribe(() => this.updateValidVoyagePoints());

    this.form.controls.arrivalDate.valueChanges.subscribe((arrivalDate) => {
      let arrivalVoyagePoint = null;

      if (arrivalDate) {
        arrivalVoyagePoint = this.arrivalVoyagePoints.find(vp => vp.date.valueOf() === arrivalDate.valueOf());
        this.selectedArrivalVoyagePoint = arrivalVoyagePoint ? [arrivalVoyagePoint] : [];
      }

      this.form.controls.arrivalVoyagePoint.setValue(arrivalVoyagePoint);
    });
  }

  private initializeData(): void {
    this.loading = true;

    
    let observables: Observable<any>[] = [this.voyageService.getVoyagePoints(), this.bookingService.getPricePerNight()];
    observableForkJoin(observables).subscribe(
      (data: any[]) => {
        this.voyagePoints = data[0];
        this.pricePerNight = data[1].price;

        this.updateValidVoyagePoints();
  
        this.minDepartureDate = this.voyagePoints.reduce((prev, curr) => {
          const currDate = curr.date;
          const prevDate = prev.date;
          return currDate < prevDate ? curr : prev;
        }).date;
  
        this.loading = false;
      }
    );
  }

  private updateValidVoyagePoints() {
    let departureDate = this.form.controls.departureDate.value;
    let departureVoyagePoint = this.form.controls.departureVoyagePoint.value;

    this.departureVoyagePoints = this.voyagePoints.filter((p) => {
      if (departureVoyagePoint) {
        return p.voyagePointId == departureVoyagePoint.voyagePointId;
      }

      return departureDate ? p.date.valueOf() === departureDate.valueOf() : true;
    });

    if (departureVoyagePoint) {
      this.updateValidArrivalPoints();
    }
  }

  private updateValidArrivalPoints() {
    let arrivalDate = this.form.controls.arrivalDate.value;
    let departureVoyagePoint = this.form.controls.departureVoyagePoint.value;

    this.arrivalVoyagePoints = this.voyagePoints.filter((p) =>
      p.voyageId == departureVoyagePoint.voyageId
      && p.date.valueOf() > departureVoyagePoint.date.valueOf()
    );

    this.minArrivalDate = this.arrivalVoyagePoints.reduce((prev, curr) => {
      const currDate = curr.date;
      const prevDate = prev.date;
      return currDate < prevDate ? curr : prev;
    }).date;

    this.disabledArrivalDates = this.getDisabledDates(this.minArrivalDate.getFullYear(), this.minArrivalDate.getMonth() + 1, this.arrivalVoyagePoints);

    if (arrivalDate) {
      this.form.controls.arrivalVoyagePoint.setValue(this.arrivalVoyagePoints[0]);
    }
  }

  public handleDepartureMonthChange(event: any): void {
    this.disabledDepartureDates = this.getDisabledDates(event.year, event.month, this.departureVoyagePoints);
  }

  public handleArrivalMonthChange(event: any): void {
    this.disabledArrivalDates = this.getDisabledDates(event.year, event.month, this.arrivalVoyagePoints);
  }

  private getDisabledDates(year: number, month: number, validVoyagePoints: VoyagePointModel[]): Date[] {
    const daysInMonth = new Date(year, month, 0).getDate();
    let disabledDates = [];

    for (let i = 1; i <= daysInMonth; i++) {
      const calendarDate = new Date(year, month - 1, i);
      const isValidArrivalDate = validVoyagePoints.some(vp => vp.date.valueOf() === calendarDate.valueOf());

      if(!isValidArrivalDate) {
        disabledDates.push(calendarDate);
      }
    }

    return disabledDates;
  }

  public getTotalNights(): number {
    let departureDate = this.form.controls.departureDate.value;
    let arrivalDate = this.form.controls.arrivalDate.value;

    if (departureDate && arrivalDate) {
      return new Date(arrivalDate - departureDate).getDate();
    }

    return 0;
  }

  public getLocationNames(date: Date) {
    return this.voyagePoints.filter(vp => vp.date.valueOf() === date.valueOf()).map(p => p.location);
  }

  public createBooking() {
    this.submitted = true;

    if(this.form.valid) {
      let createBooking: CreateBookingModel = {
        customerFirstName: this.form.controls.customerFirstName.value,
        customerLastName: this.form.controls.customerLastName.value,
        departureVoyagePointId: this.form.controls.departureVoyagePoint.value.voyagePointId,
        arrivalVoyagePointId: this.form.controls.arrivalVoyagePoint.value.voyagePointId,
      };
  
      this.loading = true;
      this.bookingService.createBooking(createBooking).subscribe((b) => {
        this.router.navigate([`booking/${b.confirmationNumber}`]);
        this.loading = false;
      });
    }
  }

  public resetForm(): void {
    this.form.reset();
  }

  public noWhitespaceValidator(control: FormControl) {
    const isWhitespace = (control.value || '').trim().length === 0;
    const isValid = !isWhitespace;
    return isValid ? null : { 'whitespace': true };
  }
}

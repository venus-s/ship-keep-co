import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookingModel } from '../models/booking.model';
import { BookingService } from '../services/booking.service';

@Component({
  selector: 'app-booking-confirmation',
  templateUrl: './booking-confirmation.component.html',
  styleUrls: ['./booking-confirmation.component.scss']
})
export class BookingConfirmationComponent implements OnInit {
  public loading: boolean = false;

  confirmedBooking: BookingModel | undefined;

  constructor(
    private route: ActivatedRoute,
    private bookingService: BookingService) { }

  ngOnInit(): void {
    this.getBooking();
  }

  getBooking(): void {
    this.loading = true;
    const confirmationNumber = this.route.snapshot.paramMap.get('confirmationNumber');
    this.bookingService.getBooking(confirmationNumber)
      .subscribe(booking => {
        this.confirmedBooking = booking
        this.loading = false;
      });
  }

}

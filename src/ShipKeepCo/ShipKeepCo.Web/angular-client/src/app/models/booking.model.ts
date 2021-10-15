export interface BookingModel {
  customerFirstName: string;
  customerLastName: string;
  departureDate: Date;
  departureLocation: string;
  arrivalDate: Date;
  arrivalLocation: string;
  totalPrice: number;
  confirmationNumber: string;
}
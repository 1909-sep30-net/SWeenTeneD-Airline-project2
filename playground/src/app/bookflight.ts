import { NumberSymbol } from '@angular/common';

export default interface Flight {
    // origin: string;
    // destination: string;
    // arrivalTime: Date;
    // departTime: Date;
    // price: number;
    // luggage: number;

    flightID: number;
    company: string;
    departureTime: Date;
    arrivalTime: Date;
    origin: string;
    destination: string;
    seatAvailable: number;
    price: number;
}
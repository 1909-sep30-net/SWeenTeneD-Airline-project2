export default interface BookFlight {
    origin: string;
    destination: string;
    arrivalTime: Date;
    departTime: Date;
    price: number;
    luggage: number;
}
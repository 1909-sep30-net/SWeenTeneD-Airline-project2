export default interface FlightStatus {
     FlightID: number;

     company:string 
     departureTime:Date
     arrivalTime:Date 
     origin:string
     destination: string
     seatAvailable: number
     price: number
    
  };
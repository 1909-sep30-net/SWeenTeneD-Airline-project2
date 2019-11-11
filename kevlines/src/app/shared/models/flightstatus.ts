export default interface FlightStatus {
     FlightID: number;

     Company:string 
     DepartureTime:Date
     ArrivalTime:Date 
     origin:string
     destination: string
     seatAvailable: number
     price: number
    
  };
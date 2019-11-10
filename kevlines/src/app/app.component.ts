import { Component, OnInit } from '@angular/core';
import { AuthService } from '../app/shared/services/auth.service';

@Component({
  // the "selector" 
  // tells angular what elements in html to replace with 
  // this component
  selector: 'app-root',
  // We connect(attach) the componet TS class(logic) to 
  // the HTML template (display)
  //(you  can also use "inline template" with template property)
  templateUrl: './app.component.html',
  //in angular, Css is encapuslate with each component 
  // you are free eot wriret that css as thought tht component
  // were teh whole world 
  // and we can have everal in this array 
  // inline styles are also an option
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {

  constructor(public auth: AuthService) {}

  ngOnInit() {
    this.auth.localAuthSetup();
    this.auth.handleAuthCallback();
  }

  openNav() 
  {
     // Set nodes to variable
     let sidenav = document.getElementById("mySidenav")
     let hidden  = document.getElementById("hide")
     let main    =  document.getElementById("main")

     // Do operations with nodes
     sidenav.style.width = "200px";
     sidenav.style.marginTop = "60px";
     hidden.style.display  = "none";
     main.style.marginLeft = "200px";
  }

  // Function to close nav   
  closeNav() 
  {
     document.getElementById("mySidenav").style.width = "0";
     document.getElementById("main").style.marginLeft = "0";
     document.getElementById("hide").style.display = "block";
  }
  
 opened= false;


}
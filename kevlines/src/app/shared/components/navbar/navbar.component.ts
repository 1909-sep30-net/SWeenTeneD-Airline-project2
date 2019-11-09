import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(public auth: AuthService) { }

  ngOnInit() {

  }

  //Function to open navbar
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
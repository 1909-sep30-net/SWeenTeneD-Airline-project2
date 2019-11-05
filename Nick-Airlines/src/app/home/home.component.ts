import { Component, OnInit } from '@angular/core';
import  {HeaderComponent} from '../header/header.component';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  
  /*
  openNav() 
    {
       // Set nodes to variable
       let sidenav = document.getElementById("mySidenav")
       let hidden  = document.getElementById("hide")
       let main    =  document.getElementById("main")

       // Do operations with nodes
       sidenav.style.width = "200px";
       sidenav.style.marginTop = "0px";
       hidden.style.display  = "none";
       main.style.marginLeft = "200px";
    }
 
    // Function to set the width and margin of the side navigation to 0 
    closeNav() 
    {
       document.getElementById("mySidenav").style.width = "0";
       document.getElementById("main").style.marginLeft = "0";
       document.getElementById("hide").style.display = "block";
    }
*/
}

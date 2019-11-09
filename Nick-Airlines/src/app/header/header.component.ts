import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
    // Function to open icon when clicked
    openNav() 
    {
       // Set nodes to variable
       let sidenav = document.getElementById("mySidenav")
       let hidden  = document.getElementById("hide")
       let main    = document.getElementById("main")

       // Do operations with nodes
       sidenav.style.width = "200px";
       sidenav.style.marginTop = "60px";
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

 opened= false;





}

import { Component, OnInit } from '@angular/core';
import {CustomerService} from '../../services/customer.service'
import Customer from '../../models/customer';
import {NavbarComponent} from '../navbar/navbar.component'
import {HttpClient} from '@angular/common/http'


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  submitForm(){
    
  }
  constructor(private customerService: CustomerService) { }

  ngOnInit() {
  }







}

import { Component, OnInit } from '@angular/core';
import { Genres } from 'src/app/helper/genres';

@Component({
  selector: 'app-partner-register',
  templateUrl: './partner-register.component.html',
  styleUrls: ['./partner-register.component.scss']
})
export class PartnerRegisterComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  username: string = ""
  password: string = ""
  repeatedPassword: string = ""
  document_number: string = ""
  email: string = ""
  genre: Genres = Genres.male
  birthday: string = ""
  name: string = ""
  lastname: string = ""
  
  

}

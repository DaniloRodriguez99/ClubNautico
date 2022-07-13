import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { DocumentTypes } from 'src/app/helper/document-types';
import { Genres } from 'src/app/helper/genres';
import { InputCustomComponent } from 'src/app/modules/shared/input-custom/input-custom.component';
import { PartnerService } from 'src/app/services/partner.service';

@Component({
  selector: 'app-partner-register',
  templateUrl: './partner-register.component.html',
  styleUrls: ['./partner-register.component.scss']
})
export class PartnerRegisterComponent implements OnInit {

  constructor( private router: Router, private partnerService: PartnerService) { }

  ngOnInit(): void {
  }

  @ViewChild("username")
  private username: InputCustomComponent = new InputCustomComponent()
  @ViewChild("password")
  private password: InputCustomComponent = new InputCustomComponent()
  @ViewChild("repeatedPassword")
  private repeatedPassword: InputCustomComponent = new InputCustomComponent()
  @ViewChild("document_number")
  private document_number: InputCustomComponent = new InputCustomComponent()
  @ViewChild("email")
  private email: InputCustomComponent = new InputCustomComponent()
  @ViewChild("genre")
  private genre: InputCustomComponent = new InputCustomComponent()
  @ViewChild("birthday")
  private birthday: InputCustomComponent = new InputCustomComponent()
  @ViewChild("name")
  private name: InputCustomComponent = new InputCustomComponent()
  @ViewChild("lastname")
  private lastname: InputCustomComponent = new InputCustomComponent()
  @ViewChild("document_type")
  private document_type: InputCustomComponent = new InputCustomComponent()

  mapData = () => {
    return {
      Name: this.name.value,
      Lastname: this.lastname.value,
      Username: this.username.value,
      DocumentTypeId: DocumentTypes[this.document_type.value],
      Password: this.password.value,
      DocumentNumber: this.document_number.value,
      Email: this.email.value,
      Birthday: this.birthday.value,
      Genre: Genres[this.genre.value]
    }
  }

  cancel = () => {
    this.router.navigateByUrl("/home")
  }

  register = () => {
    this.partnerService.signUp(this.mapData())
  }

  

}

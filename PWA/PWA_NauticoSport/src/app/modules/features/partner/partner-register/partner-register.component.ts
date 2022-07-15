import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, Form, FormBuilder, FormControl, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomValidations } from 'src/app/helper/custom-validations';
import { DocumentTypes } from 'src/app/helper/document-types';
import { Genres } from 'src/app/helper/genres';
import { regularExpressions } from 'src/app/helper/regularExpressions';
import { InputCustomComponent } from 'src/app/modules/shared/input-custom/input-custom.component';
import { PartnerService } from 'src/app/services/partner.service';

@Component({
  selector: 'app-partner-register',
  templateUrl: './partner-register.component.html',
  styleUrls: ['./partner-register.component.scss']
})
export class PartnerRegisterComponent implements OnInit {

  constructor( private router: Router,
    private partnerService: PartnerService,
    private fb: FormBuilder) { }

  ngOnInit(): void {
  }

  private customValidations : CustomValidations = new CustomValidations();

  baseRootMessage = "inputs.messages."

  usernameMessage: string = "user";
  passwordMessage: string = "ppass";
  repeatedPasswordMessage: string = "repe";
  documentNumberMessage: string = "docu";
  emailMessage: string = "email";
  genreMessage: string = "asd";
  birthdayMessage: string = "asd";
  nameMessage: string = "asd";
  lastnameMessage: string = "asd";
  documentTypeMessage: string = "asd";
  

  signUpFormGroup = this.fb.group({
    username: ["", [
      Validators.required, 
      Validators.maxLength(15),
      Validators.minLength(8)
    ]],
    password: ["", [
      Validators.required, 
      Validators.maxLength(12),
      Validators.minLength(8),
      this.customValidations.passwordRegExp()
    ]],
    repeatedPassword: ["", [
      Validators.required, 
      Validators.maxLength(12),
      Validators.minLength(8),
      this.customValidations.passwordRegExp()
    ]]
    ,
    documentNumber: ["", [
      Validators.required, 
      Validators.maxLength(9),
      Validators.minLength(9),
      this.customValidations.numberOnly()
    ]],
    email: ["", [
      Validators.required,
      Validators.minLength(10),
      Validators.maxLength(20),
      Validators.email,
      this.customValidations.emailRegExp()

    ]],
    genre: ["", [
      Validators.required
    ]],
    birthday: ["", [
      Validators.required
    ]],
    name: ["", [
      Validators.required,
      Validators.maxLength(15),
      Validators.minLength(4),
    ]],
    lastname: ["", [
      Validators.required,
      Validators.maxLength(15),
      Validators.minLength(4),
    ]],
    documentType: ["", [
      Validators.required
    ]],
  },{
    validators: this.customValidations.passwordMatch(),
    updateOn: "change" });

  cancel = () => {
    this.router.navigateByUrl("/home")
  }
  
  onSubmit = () => {
    if(this.signUpFormGroup.valid) {
      this.partnerService.signUp(this.signUpFormGroup.value)
    }
  }

}

import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, Form, FormBuilder, FormControl, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CustomValidations } from 'src/app/helper/custom-validations';
import { DocumentTypes, DocumentTypesMapper } from 'src/app/helper/document-types';
import { Genres, GenresMapper } from 'src/app/helper/genres';
import { regularExpressions } from 'src/app/helper/regularExpressions';
import { InputCustomComponent } from 'src/app/modules/shared/input-custom/input-custom.component';
import { PartnerService } from 'src/app/services/partner.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-partner-register',
  templateUrl: './partner-register.component.html',
  styleUrls: ['./partner-register.component.scss']
})
export class PartnerRegisterComponent implements OnInit {

  constructor( private router: Router,
    private userService: UserService,
    private fb: FormBuilder) { }
    isSubmitted = false;

  ngOnInit(): void {
    this.isSubmitted = false;
  }

  private customValidations : CustomValidations = new CustomValidations();

  baseRootMessage = "inputs.messages."


  usernameMessage: string = "inputs.username.message"
  passwordMessage: string = "inputs.password.message"
  repeatedPasswordMessage: string = "inputs.repeatedPassword.message"
  documentNumberMessage: string = "inputs.documentNumber.message"
  emailMessage: string = "inputs.email.message"
  genreMessage: string = "inputs.genres.message"
  birthdayMessage: string = "inputs.birthday.message"
  nameMessage: string = "inputs.name.message"
  lastnameMessage: string = "inputs.lastname.message"
  documentTypeMessage: string = "inputs.documentTypes.message"

  signUpFormMessage: string = "inputs.common_messages.formWithErrors";

  genresMapped = GenresMapper.map();
  documentTypeMapped = DocumentTypesMapper.map();

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
    ]],
    documentNumber: ["", [
      Validators.required, 
      Validators.maxLength(8),
      Validators.minLength(8),
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
      this.userService.signUpPartner(this.signUpFormGroup.value).then((response) => {

      })
    }
    this.isSubmitted = true;
  }

}

import { AbstractControl } from "@angular/forms";
import { regularExpressions } from "./regularExpressions";
import { Form, FormBuilder, FormControl, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';

export class CustomValidations {

    constructor() {}

    public numberOnly = () => { //In regularExpressions.ts are the types of regular expressions
        return (control: AbstractControl) : ValidationErrors | null => {
            let regExpList = new regularExpressions();
            let regExp = regExpList.getRegExp("numbersOnly")
            let isMatch = regExp.test(control.value);
            return isMatch ? null : {"numbersOnly": {value: isMatch}} //The null meaning is that the validation was ok
          }
    }
    
    public emailRegExp = () => { //In regularExpressions.ts are the types of regular expressions
        return (control: AbstractControl) : ValidationErrors | null => {
            let regExpList = new regularExpressions();
            let regExp = regExpList.getRegExp("email")
            let isMatch = regExp.test(control.value);
            return isMatch ? null : {"emailRegExp": {value: isMatch}} //The null meaning is that the validation was ok
          }
    }
    
    public passwordRegExp = () => { //In regularExpressions.ts are the types of regular expressions
        return (control: AbstractControl) : ValidationErrors | null => {
            let regExpList = new regularExpressions();
            let regExp = regExpList.getRegExp("password")
            let isMatch = regExp.test(control.value);
            return isMatch ? null : {"passwordRegExp": {value: isMatch}} //The null meaning is that the validation was ok
          }
    }

    public passwordMatch = () : ValidatorFn => {
        return (control: AbstractControl) : ValidationErrors | null => {
            let isMatch = control.value.repeatedPassword == control.value.password
            return isMatch ? null : {"passwordMatch": {value: isMatch}}
          }
    }
}

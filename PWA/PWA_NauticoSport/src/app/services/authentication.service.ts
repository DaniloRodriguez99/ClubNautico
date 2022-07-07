import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import {HttpParams} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  login = (user: string, pass: string) => {
    let loginRequest = (user: string, pass: string) => {
  
      let response =  this.http.post('https://localhost:7259/api/auth/login', {
        userName: user,
        password: pass
      });
      return response;
    }

    loginRequest(user, pass).subscribe((response:any) => {
      sessionStorage.setItem('auth-token', response.token); 
    })
  }

  
}

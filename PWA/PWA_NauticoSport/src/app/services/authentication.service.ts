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

    const options = { params: new HttpParams().set('userName', user) };
    options.params.set('passsword',pass);

    return this.http.post('https://localhost:7259/api/auth/login', {
      userName: user,
      password: pass
    });
  }
}

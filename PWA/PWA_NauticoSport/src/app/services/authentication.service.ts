import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, Subscription, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import {HttpParams} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  public onLoginChange = new Subject();

  login = (user: string, pass: string) : Promise<Observable<any>> => {
    return new Promise<Observable<any>>((resolve, reject) => {
        let loginRequest = (user: string, pass: string) => {
          let response =  this.http.post('https://localhost:7259/api/auth/login', {
            userName: user,
            password: pass
          });
          return response;
        }

        return loginRequest(user, pass).pipe(
          catchError((err) => {
            reject(err.error);
            return throwError(() => new Error(err.error))
          })
        )
        .subscribe((response:any) => {
          sessionStorage.setItem('auth-token', response.token); 
          sessionStorage.setItem('username', response.user.username); 
          sessionStorage.setItem('userId', response.user.userId); 
          sessionStorage.setItem('ci', response.user.ci); 
          sessionStorage.setItem('userType', response.user.userType); 
          this.onLoginChange.next(response)
          resolve(response)
        })
      }
    )
  }

  
}

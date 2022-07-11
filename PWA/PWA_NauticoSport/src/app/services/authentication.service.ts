import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, Subscription, throwError, of } from 'rxjs';
import { catchError, map, retry, delay } from 'rxjs/operators';
import {HttpParams} from "@angular/common/http";
import { JwtHelperService, JWT_OPTIONS } from "@auth0/angular-jwt";
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService, private router: Router) { }

  timeout = 0;
  tokenSubscription = new Subscription();

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
          this.storeUserData(response);
          this.onLoginChange.next(response)
          resolve(response)
        })
      }
    )
  }

  logout() {
    this.tokenSubscription.unsubscribe();
    localStorage.clear();
    this.router.navigate(["/login"])
    this.onLoginChange.next(null);
  }

  storeUserData = (data: any) => {
    let date = this.jwtHelper.getTokenExpirationDate(data.token);
    if(date != null) 
    {
      this.timeout = date.valueOf() - new Date().valueOf()
    }

    localStorage.setItem('access_token', data.token); 
    localStorage.setItem('username', data.user.username); 
    localStorage.setItem('userId', data.user.userId); 
    localStorage.setItem('ci', data.user.ci); 
    localStorage.setItem('userType', data.user.userType); 

    this.expirationCounter(this.timeout)
  }
  
  expirationCounter(timeout: any) {
    this.tokenSubscription.unsubscribe();
    this.tokenSubscription = of(null).pipe(delay(timeout)).subscribe((expired) => {
      this.logout();
    })
  }
}

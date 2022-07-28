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
  private _isLogged : boolean = false;

  public onLoginChange = new Subject<void>();

  // Log the user in, sending the username and the password of the user
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
          this._isLogged = true;
          this.onLoginChange.next(response)
          resolve(response)
        })
      }
    )
  }

  // Log the user out, and navigate to the beginning of the app
  logout() {
    this.tokenSubscription.unsubscribe();
    localStorage.clear();
    this.router.navigate(["/login"])
    this._isLogged = false;
    this.onLoginChange.next();
  }

  // Store the user data that we will use in other places
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

  // Used for check if the user is logged ,true is logged, false is not logged
  isLogged = () : boolean => {
    return this._isLogged;
  }

  // Check if the token has already expired, used in the initialization of the app
  // is used to valdiate if the user have other token of previos session and if it is available
  expirationValidator() {
    let date = this.jwtHelper.getTokenExpirationDate(localStorage.getItem('access_token')?.toString());
    if(date != null) 
    {
      this.timeout = date.valueOf() - new Date().valueOf()
      this.expirationCounter(this.timeout); // Renew the regressive counter, if the timeout has expired then the expirationCounter method will logOut the user
    }
  }
  
  //Regressive counter for the token expiration
  expirationCounter(timeout: any) {
    if(timeout > 0) {
      this._isLogged = true;
      this.onLoginChange.next()
      this.tokenSubscription.unsubscribe();
      this.tokenSubscription = of(null).pipe(delay(timeout)).subscribe((expired) => {
        this.logout();
      })
    } else { this.logout(); }
  }

  // TODO TODAVIA NO ESTA FUNCIONANDO
  refreshToken = () => {
    return new Promise((resolve, reject) => {
      let request = this.http.get("https://localhost:7259/api/auth/refreshToken")

      request.pipe(
        catchError((err) => {
          reject(err);
          return throwError(() => {return new Error(err)})
        })
      )
      .subscribe((result) => {
        this.storeUserData(result); 
        resolve(result)
      })
    }) 
  }
}

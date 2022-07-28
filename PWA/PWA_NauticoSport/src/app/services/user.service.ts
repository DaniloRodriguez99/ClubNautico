import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, Subject, Subscription, throwError } from 'rxjs';
import { RoleEnum } from 'src/app/helper/role-enum';
import { Filter } from '../helper/filter';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseURL = "https://localhost:7259"

  constructor(private http: HttpClient, private router: Router) { }

  timeout = 0;
  tokenSubscription = new Subscription();

  public onLoginChange = new Subject();

  signUpPartner = (data: any) : Promise<Observable<any>> => {
    return this.signUp(data, RoleEnum.partner );
  }

  private signUp = (data: any, role: number) : Promise<Observable<any>> => {
    return new Promise<Observable<any>>((resolve, reject) => {
      let request = () => {
        let response = this.http.post(this.baseURL + '/api/user/signup', 
        { 
          Name: data.name,
          Lastname: data.lastname,
          Username: data.username,
          Password: data.password,
          RepeatedPassword: data.repeatedPassword,
          DocumentType: Number.parseInt(data.documentType),
          DocumentNumber: data.documentNumber,
          Email: data.email,
          Birthday: data.birthday,
          Genre: Number.parseInt(data.genre),
          Role: role
        }
        );
        return response;
      }
  
      return request()
      .pipe(
        catchError((err) => {
          reject(err.error);
          return throwError(() => new Error(err.error))
        })
      )
      .subscribe((response:any) => {
        resolve(response)
      })
    });
  }

  public getUsers = (pageSize: number, from: number, filters: Filter) : Promise<Observable<any>> => {
    return new Promise<Observable<any>>((resolve, reject) => {
      let request = () => {
        let response = this.http.get(this.baseURL + "/api/user/users",{
          params: {
            PageSize: pageSize,
            From: from,
            Filters: JSON.stringify(filters)
          }
        })
        return response;
      }

      return request()
      .pipe(
        catchError((err) => {
          reject(err.error)
          return throwError(() => new Error(err.error))
        })
      )
      .subscribe((response: any) => {
        resolve(response)
      })
  })
  }
}


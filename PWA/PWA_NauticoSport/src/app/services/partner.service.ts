import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PartnerService {

  constructor(private http: HttpClient) { }

  baseURL = "https://localhost:7259"

  getPartnerByPartnerId = () => {
    let request = () => {
      let response =  this.http.get(this.baseURL + '/api/partner', {});
      return response;
    }
    return request().subscribe((response:any) => {
      return response;
    })
  }

  signUp = (data: any) : Promise<Observable<any>> => {
    return new Promise<Observable<any>>((resolve, reject) => {
      let request = () => {
        let response = this.http.post(this.baseURL + '/api/partner/signup', 
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
          Genre: Number.parseInt(data.genre)
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
}


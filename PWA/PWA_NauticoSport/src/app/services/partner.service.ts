import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

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

  signUp = (data: any) => {
    let request = () => {
      let response = this.http.post(this.baseURL + '/api/partner/signup', 
        data
      );
      return response;
    }

    return request().subscribe((response:any) => {
      return response
    })
  }
}


import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PartnerService {

  constructor(private http: HttpClient) { }

  getPartnerByPartnerId = () => {
    let request = () => {
      let response =  this.http.get('https://localhost:7259/api/partner', {});
      return response;
    }
    return request().subscribe((response:any) => {
      return response;
    })
  }
}


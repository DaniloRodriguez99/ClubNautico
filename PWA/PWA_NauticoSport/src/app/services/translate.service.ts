import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TranslateService {

  data: any = [];

  constructor(private http: HttpClient) { }

  use = (lang: string) : Promise<{}> => {
    return new Promise<{}>((resolve, reject) => {
        const langPath = `assets/${lang || 'es'}.json`
        this.http.get(langPath).pipe(catchError(
          (err) => {
            reject();
            return throwError(() => new Error(err))
          }
        ))
        .subscribe(
          response => {
            this.data = response || {};
            resolve(this.data);
          }
        )
      }
    )
  }
}

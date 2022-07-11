import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(
    private router: Router
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {

    let token = sessionStorage.getItem("access_token");

    let auth = request.clone({
      setHeaders: {
        authorization: `Bearer ${ token ? token : "" }`
      }
    })
    
    return next.handle(auth).pipe(
      catchError((e: HttpErrorResponse) => {
        if (e.status === 401) {
          this.router.navigateByUrl('/login');
        }

        return throwError(() => new Error(e.message));
      })
    );
  }
}

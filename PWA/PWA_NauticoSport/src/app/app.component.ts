import { Component } from '@angular/core';
import { AuthenticationService } from './services/authentication.service';
import { TranslateService } from './services/translate.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(
    private authService: AuthenticationService,
    private translateService: TranslateService
    ) {}

    role:any = localStorage.getItem('role')

  ngOnInit(): void {
    this.authService.refreshToken();
    this.authService.expirationValidator();
    this.authService.onLoginChange.subscribe((data: any) => {
      if(data != null) {
        this.role = data.user.role;
      } else {
        this.role = data;
      }
    })
  }
  
  title = 'PWA_NauticoSport';
}

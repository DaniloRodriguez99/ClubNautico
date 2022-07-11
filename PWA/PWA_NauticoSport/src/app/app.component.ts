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

  userType:any = localStorage.getItem('userType')

  ngOnInit(): void {
    this.authService.onLoginChange.subscribe((data: any) => {
      if(data != null) {
        this.userType = data.user.userType;
      } else {
        this.userType = data;
      }
    })
  }
  
  title = 'PWA_NauticoSport';
}

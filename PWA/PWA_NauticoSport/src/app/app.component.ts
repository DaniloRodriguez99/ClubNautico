import { Component } from '@angular/core';
import { AuthenticationService } from './services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private authService: AuthenticationService) {}

  userType: string = "" 

  ngOnInit(): void {
    this.authService.onLoginChange.subscribe((data: any) => {
      this.userType = data.user.userType;
    })
  }
  
  title = 'PWA_NauticoSport';
}

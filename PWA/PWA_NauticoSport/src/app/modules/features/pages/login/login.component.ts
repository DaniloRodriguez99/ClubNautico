import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { InputCustomComponent } from 'src/app/modules/shared/input-custom/input-custom.component';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  @ViewChild("passInput")
  private passInput: InputCustomComponent = new InputCustomComponent()

  @ViewChild("userInput")
  private userInput: InputCustomComponent = new InputCustomComponent()
  
  constructor(
    private route: ActivatedRoute,
    private authService: AuthenticationService
  ) {}

  operationResult: String = ''

  ngOnInit() {
    this.route.queryParams.subscribe(params => {
      //this.name = params['name'];
    });
  }
  
  login = () => {
    this.authService.login(this.userInput.value, this.passInput.value);
  }
}

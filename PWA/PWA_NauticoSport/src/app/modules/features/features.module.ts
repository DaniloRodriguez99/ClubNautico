import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// Pages
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { PartnerComponent } from './pages/partner/partner.component';

//Modules
import { FeaturesRoutingModule } from './features.routing.module';
import { SharedModule } from '../shared/shared.module';

//Components
import { PartnerRegisterComponent } from './partner/partner-register/partner-register.component';
import { PartnerModifyComponent } from './partner/partner-modify/partner-modify.component';
import { PartnerEliminateComponent } from './partner/partner-eliminate/partner-eliminate.component';
import { PartnerDetailComponent } from './partner/partner-detail/partner-detail.component';
import { PartnerListComponent } from './partner/partner-list/partner-list.component';

//services
import { AuthenticationService } from 'src/app/services/authentication.service';

@NgModule({
  declarations: [
    LoginComponent,
    HomeComponent,
    PageNotFoundComponent,
    PartnerRegisterComponent,
    PartnerComponent,
    PartnerModifyComponent,
    PartnerEliminateComponent,
    PartnerDetailComponent,
    PartnerListComponent
  ],
  imports: [
    CommonModule,
    FeaturesRoutingModule,
    SharedModule
  ],
  exports: [
    LoginComponent,
    HomeComponent,
    PageNotFoundComponent,
    PartnerComponent
  ],
  providers: [
    AuthenticationService
  ]
})
export class FeaturesModule { }

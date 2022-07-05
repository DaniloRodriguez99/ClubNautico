import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { FeaturesRoutingModule } from './features.routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    LoginComponent,
    HomeComponent,
    PageNotFoundComponent
  ],
  imports: [
    CommonModule,
    FeaturesRoutingModule,
    SharedModule
  ],
  exports: [
    LoginComponent,
    HomeComponent,
    PageNotFoundComponent
  ]
})
export class FeaturesModule { }

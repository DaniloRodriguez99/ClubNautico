import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';



@NgModule({
  declarations: [
    LoginComponent,
    PageNotFoundComponent,
    HomeComponent],
  imports: [
    CommonModule
  ],
  exports: [
    LoginComponent,
    PageNotFoundComponent,
    HomeComponent],
})
export class PagesModule { }

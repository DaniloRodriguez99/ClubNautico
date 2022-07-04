import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './common/navbar/navbar.component';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NavbarComponent
  ],
  exports: [ NavbarComponent ]
})
export class CommonComponentsModule { }

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Modules
import { AppRoutingModule } from 'src/app/app-routing.module';

//Components
import { NavbarComponent } from './navbar/navbar.component';
import { FeatureContainerComponent } from './feature-container/feature-container.component';
import { InputCustomComponent } from './input-custom/input-custom.component';

@NgModule({
  declarations: [NavbarComponent,
    FeatureContainerComponent,
    InputCustomComponent],
  imports: [
    CommonModule,
    AppRoutingModule
  ],
  exports: [NavbarComponent,
    FeatureContainerComponent,
    InputCustomComponent]
})
export class SharedModule { }

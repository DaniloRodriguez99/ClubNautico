import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Modules
import { AppRoutingModule } from 'src/app/app-routing.module';

//Components
import { NavbarComponent } from './navbar/navbar.component';
import { FeatureContainerComponent } from './feature-container/feature-container.component';
import { InputCustomComponent } from './input-custom/input-custom.component';
import { SitemapComponent } from './sitemap/sitemap.component';
import { MessageComponent } from './message/message.component';
import { TranslatePipe } from 'src/app/pipes/translate.pipe';
import { BottomNavBarComponent } from './bottom-nav-bar/bottom-nav-bar.component';

@NgModule({
  declarations: [NavbarComponent,
    FeatureContainerComponent,
    InputCustomComponent,
    SitemapComponent,
    MessageComponent,
    TranslatePipe,
    BottomNavBarComponent,
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
  ],
  exports: [NavbarComponent,
    FeatureContainerComponent,
    InputCustomComponent,
    SitemapComponent,
    MessageComponent,
    TranslatePipe,
    BottomNavBarComponent,
  ],
  providers: [
  ]
})
export class SharedModule { }

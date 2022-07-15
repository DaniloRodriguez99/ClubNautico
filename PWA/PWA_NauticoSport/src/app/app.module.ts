import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { FeaturesModule } from './modules/features/features.module';
import { SharedModule } from './modules/shared/shared.module';
import { AuthInterceptor } from './helper/auth.interceptor';
import { TranslatePipe } from './pipes/translate.pipe';
import { TranslateService } from './services/translate.service';
import { JwtHelperService, JWT_OPTIONS  } from '@auth0/angular-jwt';
import { ReactiveFormsModule } from '@angular/forms';

export function setupTranslateServiceFactory(
  service: TranslateService): Function {
  return () => service.use('es');
}

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FeaturesModule,
    ServiceWorkerModule.register('ngsw-worker.js', {
      enabled: environment.production,
    }),
    SharedModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    TranslateService,
    {
      provide: APP_INITIALIZER,
      useFactory: setupTranslateServiceFactory,
      deps: [
        TranslateService
      ],
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    JwtHelperService
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }

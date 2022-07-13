import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
//Pages
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';
import { PartnerComponent } from './pages/partner/partner.component';

//Components
import { PartnerDetailComponent } from './partner/partner-detail/partner-detail.component';
import { PartnerListComponent } from './partner/partner-list/partner-list.component';
import { PartnerModifyComponent } from './partner/partner-modify/partner-modify.component';
import { PartnerRegisterComponent } from './partner/partner-register/partner-register.component';
import { PartnerDeleteComponent } from './partner/partner-delete/partner-delete.component';

const routes: Routes = [
    { path: 'login', component: LoginComponent},
    { path: 'home', component: HomeComponent },
    { path: 'partner', component: PartnerComponent, children: [
        { path: 'register', component: PartnerRegisterComponent},
        { path: 'eliminate', component: PartnerDeleteComponent},
        { path: 'modify', component: PartnerModifyComponent},
        { path: 'list', component: PartnerListComponent},
        { path: 'detail', component: PartnerDetailComponent},
        { path: '', component: PartnerRegisterComponent },
    ]},
    { path: '**', component: PageNotFoundComponent },
    { path: '', component: LoginComponent },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class FeaturesRoutingModule { }
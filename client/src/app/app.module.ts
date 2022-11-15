import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginComponent } from './account/login/login.component';
import { AppRoutingModule } from './app-routing.module';
import { TopNavComponent } from './mastertheme/top-nav/top-nav.component';
import { LayoutComponent } from './mastertheme/layout/layout.component';
import { AsideNavComponent } from './mastertheme/aside-nav/aside-nav.component';
import { FooterNavComponent } from './mastertheme/footer-nav/footer-nav.component';

import { PortalRoutingModule } from './mastertheme/layout/layout-routing.module';

import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LayoutModule } from './mastertheme/layout/layout.module';
import { jqxDataTableModule } from 'jqwidgets-ng/jqxdatatable';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CreatePatientComponent } from './create-patient/create-patient.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
  
  
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    AppRoutingModule,
    LayoutModule,
    PortalRoutingModule,
    jqxDataTableModule,
    HttpClientModule,
    FontAwesomeModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

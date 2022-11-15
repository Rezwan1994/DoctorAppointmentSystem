import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from 'src/app/home/home.component';
import { PatientsComponent } from 'src/app/patients/patients.component';

import { HttpClientModule } from '@angular/common/http';
import { LayoutComponent } from './layout.component';
import { TopNavComponent } from '../top-nav/top-nav.component';
import { AsideNavComponent } from '../aside-nav/aside-nav.component';
import { FooterNavComponent } from '../footer-nav/footer-nav.component';
import { PortalRoutingModule } from './layout-routing.module';

import { CreatePatientComponent } from 'src/app/create-patient/create-patient.component';
import { jqxDataTableModule } from 'jqwidgets-ng/jqxdatatable';




@NgModule({
  declarations: [   HomeComponent,
    PatientsComponent,
    CreatePatientComponent,
    TopNavComponent,
    LayoutComponent,
    AsideNavComponent,
    FooterNavComponent,
    ],
  imports: [
    CommonModule,
    HttpClientModule,
    PortalRoutingModule,
    jqxDataTableModule
  ]
})


export class LayoutModule { }

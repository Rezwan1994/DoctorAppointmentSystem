


//import { RptInvestStatusComponent } from '../rptInvestmentStatus/rptInvestmentStatus.component';

import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CreatePatientComponent } from "src/app/create-patient/create-patient.component";
import { HomeComponent } from "src/app/home/home.component";
import { PatientsComponent } from "src/app/patients/patients.component";
import { LayoutComponent } from "./layout.component";


const portalRoutes: Routes = [
  {
    path: 'portal',
    component: LayoutComponent,
    children: [
      
        //{path: 'home', component: HomeComponent, canActivate: [SuperAdminRoleGuard]},
        {path: 'home', component: HomeComponent},
        {path: 'patients', component: PatientsComponent},
        {path: 'createpatient', component: CreatePatientComponent},
        ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(portalRoutes)],
  exports: [RouterModule]
})
export class PortalRoutingModule {}
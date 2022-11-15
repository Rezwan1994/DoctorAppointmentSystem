import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './account/login/login.component';

//import { TestErrorComponent } from './core/test-error/test-error.component';
//import { ServerErrorComponent } from './core/server-error/server-error.component';
//import { NotFoundComponent } from './core/not-found/not-found.component';
//import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [

  {path: '', component: LoginComponent},

  {path: 'login', component: LoginComponent},

  
];


@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

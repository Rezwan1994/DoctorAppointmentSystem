import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IUserModel } from 'src/app/Model/UserModel';
import { SecurityServiceService } from 'src/app/Services/securityservice.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(public securityService: SecurityServiceService,
    private router: Router) { 
    
  }

  login() {
    console.log(this.securityService.userModel.userName);
    console.log(this.securityService.userModel.password);
    this.securityService.login().subscribe(
      (res) => {
        debugger;
        var result = res as IUserModel;
        if (result.token != '') {
          localStorage.setItem('token', result.token);
          //localStorage.setItem('isAdmin', String(result.isAdmin));
          localStorage.setItem('Role', result.role);
          this.router.navigate(['portal/home']);
        }
      },
      (err) => {
        alert('Invalid User Name or Password');
      }
    );
  }

  register() {
    this.router.navigate(['/register']);
  }
  ngOnInit(): void {
  }
  onSubmit()
  {

    this.router.navigate(['/portal/home'])
  }
}

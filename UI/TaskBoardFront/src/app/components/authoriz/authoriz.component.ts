import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import ValidateForm from 'src/app/helpers/validateform';
import { NgToastService } from 'ng-angular-popup';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-authoriz',
  templateUrl: './authoriz.component.html',
  styleUrls: ['./authoriz.component.css']
})
export class AuthorizComponent {

  type: string = "password";
  isText: boolean = false;
  eyeIcon: string = "fa-eye-slash";

  authorizForm!: FormGroup;
  constructor(private fb: FormBuilder, 
    private auth: AuthService, 
    private router: Router, 
    private toast: NgToastService, 
    private userStore: UserStoreService) { }

  ngOnInit(): void {
    this.authorizForm = this.fb.group({
      login: ['', Validators.required],
      password: ['', Validators.required],
      codeword: [''],
      role:['']
    })
  }

  hideShowPass(){
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
    this.isText ? this.type = "text" : this.type = "password";
  }

  onAuthoriz(){
    if(this.authorizForm.valid){
      this.auth.authoriz(this.authorizForm.value)
      .subscribe({
        next:(res=>{
          alert(res.message)
          this.authorizForm.reset();
          this.auth.storeToken(res.token);
          const tokenPayLoad = this.auth.decodedToken();
          this.userStore.setLoginForStore(tokenPayLoad.login);
          this.userStore.setRoleForStore(tokenPayLoad.role);
          this.toast.success({detail:"SUCCESS", summary:res.message, duration: 5000});
          this.router.navigate(['projects']);
        }),
        error:(err=>{
          alert(err?.error.message)
        })
      })
    }else {
      ValidateForm.validateAllFormFields(this.authorizForm);
      alert("Your form is invalid")
    }
  }
}

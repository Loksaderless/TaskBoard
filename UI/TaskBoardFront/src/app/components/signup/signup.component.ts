import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import ValidateForm from 'src/app/helpers/validateform';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {

  type: string = "password";
  isText: boolean = false;
  eyeIcon: string = "fa-eye-slash";
  
  typeCodeword: string = "password";
  isTextCodeword: boolean = false;
  eyeIconCodeword: string = "fa-eye-slash";

  signUpForm!: FormGroup;
  constructor(private fb : FormBuilder, private auth: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.signUpForm = this.fb.group({
      login: ['', Validators.required],
      password: ['', Validators.required],
      codeword: ['', Validators.required],
      role:['']
    })
  }

  hideShowPass(){
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "fa-eye" : this.eyeIcon = "fa-eye-slash";
    this.isText ? this.type = "text" : this.type = "password";
  }

  hideShowCodeword(){
    this.isTextCodeword = !this.isTextCodeword;
    this.isTextCodeword ? this.eyeIconCodeword = "fa-eye" : this.eyeIconCodeword = "fa-eye-slash";
    this.isTextCodeword ? this.typeCodeword = "text" : this.typeCodeword = "password";
  }

  onSignup(){
    if(this.signUpForm.valid){
      this.auth.signUp(this.signUpForm.value)
      .subscribe({
        next:(res=>{
          alert(res.message);
          this.signUpForm.reset();
          this.router.navigate(['authoriz']);
        }),
        error:(err=>{
          alert(err?.error.message)
        })
      })
    }else {
      ValidateForm.validateAllFormFields(this.signUpForm);
    }
  }
}

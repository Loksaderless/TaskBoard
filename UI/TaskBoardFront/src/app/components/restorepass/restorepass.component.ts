import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import ValidateForm from 'src/app/helpers/validateform';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-restorepass',
  templateUrl: './restorepass.component.html',
  styleUrls: ['./restorepass.component.css']
})
export class RestorepassComponent {

  typeCodeword: string = "password";
  isTextCodeword: boolean = false;
  eyeIconCodeword: string = "fa-eye-slash";

  restoreForm!: FormGroup;
  constructor(private fb: FormBuilder, private auth: AuthService) { }

  ngOnInit(): void {
    this.restoreForm = this.fb.group({
      login: ['', Validators.required],
      codeword: ['', Validators.required],
      password: [''],
      role:['']
    })
  }

  hideShowCodeword(){
    this.isTextCodeword = !this.isTextCodeword;
    this.isTextCodeword ? this.eyeIconCodeword = "fa-eye" : this.eyeIconCodeword = "fa-eye-slash";
    this.isTextCodeword ? this.typeCodeword = "text" : this.typeCodeword = "password";
  }

  onRestore(){
    if(this.restoreForm.valid){
      this.auth.restorepass(this.restoreForm.value)
      .subscribe({
        next:(res)=>{
          alert(res.message)
        },
        error:(err)=>{
          alert(err?.error.message)
        }
      })
    }else {
      ValidateForm.validateAllFormFields(this.restoreForm);
    }
  }
}

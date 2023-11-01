import { Component, Input } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent {

  constructor(private service:UserService) { }

  Id!:string;
  Login!:string;
  Password!:string;
  Codeword!:string;
  Role:string='';

  addUser(){
    var val = {Id:this.Id,
               Login:this.Login,
               Password:this.Password,
               Codeword:this.Codeword,
               Role:this.Role};
    this.service.addUser(val).subscribe(res=>{
      alert(res.toString());
    });
  }
}

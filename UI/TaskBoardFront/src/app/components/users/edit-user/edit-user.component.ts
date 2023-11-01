import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent {
  @Input() us:any;

  constructor(private service:UserService) { }

  Id!:string;
  Role!:string;
  Login:string='';
  Password:string='';
  Codeword:string='';

  RoleList:any=["User", "Manager", "Admin"];

  ngOnInit(): void {
    this.Id=this.us.id;
    this.Role=this.us.role;
  }

  updateRoleUser(){
    var val = {Id:this.Id,
              Role:this.Role,
              Login:this.Login,
              Password:this.Password,
              Codeword:this.Codeword};
    this.service.updateRoleUser(val).subscribe(res=>{
    alert(res.toString());
    });
  }
}

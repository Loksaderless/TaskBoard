import { Component } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-show-user',
  templateUrl: './show-user.component.html',
  styleUrls: ['./show-user.component.css']
})
export class ShowUserComponent {

  constructor(private service:UserService) { }

  UserList:any=[];

  ModalTitle!:string;
  ActivateAddUserComp:boolean=false;
  ActivateEditUserComp:boolean=false;
  us:any;

  ngOnInit(): void{
    this.refreshUserList();
  }

  addClick(){
    this.us={
      Login:"",
      Password:"",
      Codeword:""     
    }
    this.ModalTitle="Add User";
    this.ActivateAddUserComp=true;
  }

  editClick(item: any){
    this.us=item;
    this.ModalTitle="Edit Role User";
    this.ActivateEditUserComp=true;
  }

  deleteClick(item: any){
    if(confirm('Are you sure?')){
      this.service.deleteUser(item.id).subscribe(data=>{
        alert(data.toString());
        this.refreshUserList();
      })
    }
  }

  closeClick(){
    this.ActivateAddUserComp=false;
    this.ActivateEditUserComp=false;
    this.refreshUserList();
  }

  refreshUserList(){
    this.service.getAll().subscribe(data=>{
      this.UserList=data;
    });
  }
}

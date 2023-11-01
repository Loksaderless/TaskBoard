import { Component, Input } from '@angular/core';
import { TaskService } from 'src/app/services/task.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-edit-task',
  templateUrl: './add-edit-task.component.html',
  styleUrls: ['./add-edit-task.component.css']
})
export class AddEditTaskComponent {
  constructor(private service:TaskService) { }

  @Input() tas:any;
  Id!:string;
  SprintId!:string;
  Name!:string;
  Description!:string;
  Comment!:string;
  User:string='';
  Files:string='';

  SprintIdList:any=[];
  UsersLoginList:any=[];

  loadSprintIdList(){
    this.service.getAllSprintId().subscribe((data:any)=>{
      this.SprintIdList=data;

      this.Id=this.tas.id;
      this.SprintId=this.tas.sprintId;
      this.Name=this.tas.name;
      this.Description=this.tas.description;
      this.Comment=this.tas.comment;
      this.User=this.tas.user;
      this.Files=this.tas.files;
    });
  }

  loadUsersLoginList(){
    this.service.getAllUsersLogin().subscribe((data:any)=>{
      this.UsersLoginList=data;
    })
  }

  ngOnInit(): void {
    this.loadSprintIdList();
    this.loadUsersLoginList();
  }

  addTask(){
    var val = {Id:this.Id,
                SprintId:this.SprintId,
                Name:this.Name,
                Description:this.Description,
                Comment:this.Comment,
                User:this.User};
    this.service.addTask(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateTask(){
    var val = {Id:this.Id,
                SprintId:this.SprintId,
                Name:this.Name,
                Description:this.Description,
                Comment:this.Comment,
                User:this.User};
    this.service.updateTask(val).subscribe(res=>{
    alert(res.toString());
    });
  }
}

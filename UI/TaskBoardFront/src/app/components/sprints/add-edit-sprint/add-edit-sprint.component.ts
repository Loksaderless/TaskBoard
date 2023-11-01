import { Component, Input } from '@angular/core';
import { SprintService } from 'src/app/services/sprint.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-edit-sprint',
  templateUrl: './add-edit-sprint.component.html',
  styleUrls: ['./add-edit-sprint.component.css']
})
export class AddEditSprintComponent {
  constructor(private service:SprintService) { }

  @Input() sprin:any;
  Id!:string;
  ProjectId!:string;
  StartSprint!:string;
  EndSprint!:string;
  Name!:string;
  Description!:string;
  Comment!:string;
  Users:string='';
  Files:string='';

  ProjectIdList:any=[];
  UsersLoginList:any=[];

  loadProjectIdList(){
    this.service.getAllProjectId().subscribe((data:any)=>{
      this.ProjectIdList=data;


      this.Id=this.sprin.id;
      this.ProjectId=this.sprin.projectId;
      this.StartSprint=this.sprin.startSprint;
      this.EndSprint=this.sprin.endSprint;
      this.Name=this.sprin.name;
      this.Description=this.sprin.description;
      this.Comment=this.sprin.comment;
      this.Users=this.sprin.users;
      this.Files=this.sprin.files;
    });
  }
  
  loadUsersLoginList(){
    this.service.getAllUsersLogin().subscribe((data:any)=>{
      this.UsersLoginList=data;
    })
  }

  ngOnInit(): void {
    this.loadProjectIdList();
    this.loadUsersLoginList();
  }

  addSprint(){
    var val = {Id:this.Id,
                ProjectId:this.ProjectId,
                StartSprint:this.StartSprint,
                EndSprint:this.EndSprint,
                Name:this.Name,
                Description:this.Description,
                Comment:this.Comment,
                Users:this.Users};
    this.service.addSprint(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateSprint(){
    var val = {Id:this.Id,
                ProjectId:this.ProjectId,
                StartSprint:this.StartSprint,
                EndSprint:this.EndSprint,
                Name:this.Name,
                Description:this.Description,
                Comment:this.Comment,
                Users:this.Users};
    this.service.updateSprint(val).subscribe(res=>{
    alert(res.toString());
    });
  }

  saveFile(event:any){
    var file=event.target.files[0];
    const formData:FormData=new FormData();
    formData.append('uploadedFile',file,file.name);

    this.service.saveFile(formData).subscribe((data:any)=>{
      this.Files=data.toString();
    })
  }
}

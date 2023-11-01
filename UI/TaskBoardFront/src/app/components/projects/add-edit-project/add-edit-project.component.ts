import { Component, Input } from '@angular/core';
import { ProjectService } from 'src/app/services/project.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-edit-project',
  templateUrl: './add-edit-project.component.html',
  styleUrls: ['./add-edit-project.component.css']
})
export class AddEditProjectComponent {
  
  constructor(private service:ProjectService) { }

  @Input() proj:any;
  Id!:string;
  Name!:string;
  Description!:string;

  ngOnInit(): void {
    this.Id=this.proj.id;
    this.Name=this.proj.name;
    this.Description=this.proj.description;
  }

  addProject(){
    var val = {Id:this.Id,
               Name:this.Name,
               Description:this.Description};
    this.service.addProject(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateProject(){
    var val = {Id:this.Id,
              Name:this.Name,
              Description:this.Description};
    this.service.updateProject(val).subscribe(res=>{
    alert(res.toString());
    });
  }
}

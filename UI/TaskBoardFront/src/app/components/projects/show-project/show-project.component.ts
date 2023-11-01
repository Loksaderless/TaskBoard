import { Component } from '@angular/core';
import { ProjectService } from 'src/app/services/project.service';

@Component({
  selector: 'app-show-project',
  templateUrl: './show-project.component.html',
  styleUrls: ['./show-project.component.css']
})
export class ShowProjectComponent {

  constructor(private service:ProjectService) { }

  ProjectList:any=[];

  ModalTitle!:string;
  ActivateAddEditProjectComp:boolean=false;
  proj:any;

  ngOnInit(): void{
    this.refreshProjList();
  }

  addClick(){
    this.proj={
      Id:0,
      Name:"",
      Description:""
    }
    this.ModalTitle="Add Project";
    this.ActivateAddEditProjectComp=true;
  }

  editClick(item: any){
    this.proj=item;
    this.ModalTitle="Edit Project";
    this.ActivateAddEditProjectComp=true;
  }

  deleteClick(item: any){
    if(confirm('Are you sure?')){
      this.service.deleteProject(item.id).subscribe(data=>{
        alert(data.toString());
        this.refreshProjList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditProjectComp=false;
    this.refreshProjList();
  }

  refreshProjList(){
    this.service.getAll().subscribe(data=>{
      this.ProjectList=data;
    });
  }

}

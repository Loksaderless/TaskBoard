import { Component } from '@angular/core';
import { SprintService } from 'src/app/services/sprint.service';

@Component({
  selector: 'app-show-sprint',
  templateUrl: './show-sprint.component.html',
  styleUrls: ['./show-sprint.component.css']
})
export class ShowSprintComponent {
  
  constructor(private service:SprintService) { }

  SprintList:any=[];

  ModalTitle!:string;
  ActivateAddEditSprintComp:boolean=false;
  sprin:any;

  ngOnInit(): void{
    this.refreshSprintList();
  }

  addClick(){
    this.sprin={
      Id:0,
      ProjectId:"",
      StartSprint:"",
      EndSprint:"",
      Name:"",
      Description:"",
      Comment:"",
      Users:"",
      Files:""
    }
    this.ModalTitle="Add Sprint";
    this.ActivateAddEditSprintComp=true;
  }

  editClick(item: any){
    this.sprin=item;
    this.ModalTitle="Edit Sprint";
    this.ActivateAddEditSprintComp=true;
  }

  deleteClick(item: any){
    if(confirm('Are you sure?')){
      this.service.deleteSprint(item.id).subscribe(data=>{
        alert(data.toString());
        this.refreshSprintList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditSprintComp=false;
    this.refreshSprintList();
  }

  refreshSprintList(){
    this.service.getAll().subscribe(data=>{
      this.SprintList=data;
    });
  }

}

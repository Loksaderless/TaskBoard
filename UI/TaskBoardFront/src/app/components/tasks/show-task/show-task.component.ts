import { Component } from '@angular/core';
import { TaskService } from 'src/app/services/task.service';

@Component({
  selector: 'app-show-task',
  templateUrl: './show-task.component.html',
  styleUrls: ['./show-task.component.css']
})
export class ShowTaskComponent {

  constructor(private service:TaskService) { }

  TaskList:any=[];

  ModalTitle!:string;
  ActivateAddEditTaskComp:boolean=false;
  tas:any;

  ngOnInit(): void{
    this.refreshTaskList();
  }

  addClick(){
    this.tas={
      Id:0,
      SprintId:"",
      Name:"",
      Description:"",
      Comment:"",
      User:"",
      Files:""
    }
    this.ModalTitle="Add Task";
    this.ActivateAddEditTaskComp=true;
  }

  editClick(item: any){
    this.tas=item;
    this.ModalTitle="Edit Task";
    this.ActivateAddEditTaskComp=true;
  }

  deleteClick(item: any){
    if(confirm('Are you sure?')){
      this.service.deleteTask(item.id).subscribe(data=>{
        alert(data.toString());
        this.refreshTaskList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditTaskComp=false;
    this.refreshTaskList();
  }

  refreshTaskList(){
    this.service.getAll().subscribe(data=>{
      this.TaskList=data;
    });
  }
}

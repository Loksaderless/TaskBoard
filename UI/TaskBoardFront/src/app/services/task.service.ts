import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private baseUrl:string = "https://localhost:7199/api/Task/"
  constructor(private http: HttpClient, private router: Router) { }

  getAll(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}tasks`)
  }

  addTask(val:any){
    return this.http.post(`${this.baseUrl}tasks`, val)
  }

  updateTask(val:any){
    return this.http.put(`${this.baseUrl}tasks`, val)
  }

  deleteTask(val:any){
    return this.http.delete(`${this.baseUrl}tasks/` + val)
  }

  getAllSprintId():Observable<any[]>{
    return this.http.get<any[]>(`${this.baseUrl}tasks/getAllSprintId`)
  }

  getAllUsersLogin():Observable<any[]>{
    return this.http.get<any[]>(`${this.baseUrl}tasks/getAllUsersLogin`)
  }

  saveFile(val:any){
    return this.http.post(`${this.baseUrl}tasks/saveFile`,val);
  }
}

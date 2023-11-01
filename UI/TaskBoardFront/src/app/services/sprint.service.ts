import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SprintService {

  private baseUrl:string = "https://localhost:7199/api/Sprint/"
  constructor(private http: HttpClient, private router: Router) { }

  getAll(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}sprints`)
  }

  addSprint(val:any){
    return this.http.post(`${this.baseUrl}sprints`, val)
  }

  updateSprint(val:any){
    return this.http.put(`${this.baseUrl}sprints`, val)
  }

  deleteSprint(val:any){
    return this.http.delete(`${this.baseUrl}sprints/` + val)
  }

  getAllProjectId():Observable<any[]>{
    return this.http.get<any[]>(`${this.baseUrl}sprints/getAllProjectId`)
  }

  getAllUsersLogin():Observable<any[]>{
    return this.http.get<any[]>(`${this.baseUrl}sprints/getAllUsersLogin`)
  }

  saveFile(val:any){
    return this.http.post(`${this.baseUrl}sprints/saveFile`,val);
  }
}

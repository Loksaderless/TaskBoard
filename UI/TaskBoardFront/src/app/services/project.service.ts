import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  private baseUrl:string = "https://localhost:7199/api/Project/"
  constructor(private http: HttpClient, private router: Router) { }

  getAll(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}projects`)
  }

  addProject(val:any){
    return this.http.post(`${this.baseUrl}projects`, val)
  }

  updateProject(val:any){
    return this.http.put(`${this.baseUrl}projects`, val)
  }

  deleteProject(val:any){
    return this.http.delete(`${this.baseUrl}projects/` + val)
  }
}

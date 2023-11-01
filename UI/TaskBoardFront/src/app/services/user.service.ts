import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl:string = "https://localhost:7199/api/User/"
  constructor(private http: HttpClient, private router: Router) { }

  getAll(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}users`)
  }

  addUser(val:any){
    return this.http.post(`${this.baseUrl}users`, val)
  }

  updateRoleUser(val:any){
    return this.http.put(`${this.baseUrl}users`, val)
  }

  deleteUser(val:any){
    return this.http.delete(`${this.baseUrl}users/` + val)
  }
}

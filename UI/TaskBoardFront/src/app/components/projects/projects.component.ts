import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserStoreService } from 'src/app/services/user-store.service';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent {
  
  public role!:string;
  public login: string = "";

  constructor(private auth: AuthService, private userStore: UserStoreService) { }

  ngOnInit() {
    this.userStore.getLoginFromStore()
    .subscribe(val=>{
      const loginFromToken = this.auth.getLoginFromToken();
      this.login = val || loginFromToken
    });

    this.userStore.getRoleFromStore()
    .subscribe(val=>{
      const roleFromToken = this.auth.getRoleFromToken();
      this.role = val || roleFromToken;
    })
  }

  logout(){
    this.auth.signOut();
  }
}

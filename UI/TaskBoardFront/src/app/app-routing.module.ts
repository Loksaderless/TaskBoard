import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizComponent } from './components/authoriz/authoriz.component';
import { SignupComponent } from './components/signup/signup.component';
import { RestorepassComponent } from './components/restorepass/restorepass.component';
import { AuthGuard } from './guards/auth.guard';
import { ProjectsComponent } from './components/projects/projects.component';
import { SprintsComponent } from './components/sprints/sprints.component';
import { TasksComponent } from './components/tasks/tasks.component';
import { UsersComponent } from './components/users/users.component';

const routes: Routes = [
  {path:'', redirectTo:'authoriz', pathMatch:'prefix'},
  {path:'authoriz', component: AuthorizComponent},
  {path:'signup', component: SignupComponent},
  {path:'restorepass', component: RestorepassComponent},
  {path:'projects', component: ProjectsComponent, canActivate: [AuthGuard]},
  {path:'sprints', component: SprintsComponent, canActivate: [AuthGuard]},
  {path:'tasks', component: TasksComponent, canActivate: [AuthGuard]},
  {path:'users', component: UsersComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

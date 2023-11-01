import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms'
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthorizComponent } from './components/authoriz/authoriz.component';
import { SignupComponent } from './components/signup/signup.component';
import { RestorepassComponent } from './components/restorepass/restorepass.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { NgToastModule, NgToastService } from 'ng-angular-popup';
import { ProjectsComponent } from './components/projects/projects.component';
import { SprintsComponent } from './components/sprints/sprints.component';
import { TasksComponent } from './components/tasks/tasks.component';
import { ShowTaskComponent } from './components/tasks/show-task/show-task.component';
import { AddEditTaskComponent } from './components/tasks/add-edit-task/add-edit-task.component';
import { AddEditSprintComponent } from './components/sprints/add-edit-sprint/add-edit-sprint.component';
import { ShowSprintComponent } from './components/sprints/show-sprint/show-sprint.component';
import { ShowProjectComponent } from './components/projects/show-project/show-project.component';
import { AddEditProjectComponent } from './components/projects/add-edit-project/add-edit-project.component';
import { UsersComponent } from './components/users/users.component';
import { ShowUserComponent } from './components/users/show-user/show-user.component';
import { AddUserComponent } from './components/users/add-user/add-user.component';
import { EditUserComponent } from './components/users/edit-user/edit-user.component';


@NgModule({
  declarations: [
    AppComponent,
    AuthorizComponent,
    SignupComponent,
    RestorepassComponent,
    ProjectsComponent,
    SprintsComponent,
    TasksComponent,
    ShowTaskComponent,
    AddEditTaskComponent,
    AddEditSprintComponent,
    ShowSprintComponent,
    ShowProjectComponent,
    AddEditProjectComponent,
    UsersComponent,
    ShowUserComponent,
    AddUserComponent,
    EditUserComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    NgToastModule
  ],
  providers: [{
    provide:HTTP_INTERCEPTORS,
    useClass:TokenInterceptor,
    multi:true
}],
  bootstrap: [AppComponent]
})
export class AppModule { }

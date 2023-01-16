import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CourseService } from './course/courses.service';
import { ListCourseComponent } from './course/list-course/list-course.component';
import { EvaluationService } from './evaluation/evaluation.service';
import { ListEvaluationComponent } from './evaluation/list-evaluation/list-evaluation.component';
import { CreateComponent } from './evaluation/create/create.component';
import { EditComponent } from './evaluation/edit/edit.component';
import { StudentService } from './evaluation/students.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    ListCourseComponent,
    ListEvaluationComponent,
    CreateComponent,
    EditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    CourseService, 
    EvaluationService,
    StudentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

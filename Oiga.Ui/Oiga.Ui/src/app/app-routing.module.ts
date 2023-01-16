import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListCourseComponent } from './course/list-course/list-course.component';
import { CreateComponent } from './evaluation/create/create.component';
import { EditComponent } from './evaluation/edit/edit.component';
import { ListEvaluationComponent } from './evaluation/list-evaluation/list-evaluation.component';

const routes: Routes = [
  { path: 'course', component: ListCourseComponent } ,
  { path: 'evaluation/:courseId/list', component: ListEvaluationComponent },
  { path: 'evaluation/:id/edit', component: EditComponent } ,
  { path: 'evaluation/create', component: CreateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

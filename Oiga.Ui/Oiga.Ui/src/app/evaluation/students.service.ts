import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { BaseService } from '../baseService';
import { Student } from './students';

@Injectable()
export class StudentService extends BaseService {

  constructor(private http: HttpClient) { super()}

    getStudents() : Observable<Student[]> {
        return this.http
        .get<Student[]>(this.UrlServiceV1 + "Student", this.ObterHeaderJson())
        .pipe(
          catchError(this.serviceError));
    }


    getStudentsCourse(courseId:string) : Observable<Student[]> {
      return this.http
      .get<Student[]>(this.UrlServiceV1 + "Student/" + courseId, this.ObterHeaderJson())
      .pipe(
        catchError(this.serviceError));
  }
    
}


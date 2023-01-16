import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";

import { Observable, throwError } from 'rxjs';
import { catchError, map } from "rxjs/operators";

import { Course } from './course';
import { BaseService } from '../baseService';

@Injectable()
export class CourseService extends BaseService {

  constructor(private http: HttpClient) { super()}

    getCourse() : Observable<Course[]> {
        return this.http
        .get<Course[]>(this.UrlServiceV1 + "Course", this.ObterHeaderJson())
        .pipe(
          catchError(this.serviceError));
    }
    
}


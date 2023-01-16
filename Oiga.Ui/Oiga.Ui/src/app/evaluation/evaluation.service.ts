import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { BaseService } from '../baseService';
import { Evaluation } from './evaluation';

@Injectable()
export class EvaluationService extends BaseService {

  constructor(private http: HttpClient) { super()}

    getEvaluation(course:string,star:number) : Observable<Evaluation[]> {
        return this.http
        .get<Evaluation[]>(this.UrlServiceV1 + "Evaluation/"+course+ "/" + star , this.ObterHeaderJson())
        .pipe(
          catchError(this.serviceError));
    }

    get(id:string) : Observable<Evaluation> {
      return this.http
      .get<Evaluation>(this.UrlServiceV1 + "Evaluation/"+id, this.ObterHeaderJson())
      .pipe(
        catchError(this.serviceError));
  }
    
    create(evaluation:Evaluation): Observable<any> {
  
      return this.http.post(this.UrlServiceV1 + 'Evaluation/', JSON.stringify(evaluation), this.ObterHeaderJson())
    
      .pipe(
        catchError(this.serviceError)
      )
    }  

    update(id:string, evaluation:Evaluation): Observable<any> {
  
      return this.http.put(this.UrlServiceV1 + 'Evaluation/' + id, JSON.stringify(evaluation), this.ObterHeaderJson())
   
      .pipe( 
        catchError(this.serviceError)
      )
    }
         
    delete(id:string){
      return this.http.delete(this.UrlServiceV1 + 'Evaluation/' + id, this.ObterHeaderJson())
    
      .pipe(
        catchError(this.serviceError)
      )
    }
}

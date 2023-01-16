import { HttpHeaders } from '@angular/common/http';
import { throwError } from 'rxjs';

export abstract class BaseService {

    protected UrlServiceV1: string = "https://localhost:7016/api/";

    protected serviceError(error: Response | any) {
        let errMsg: string;
  
        if (error instanceof Response) {
  
            errMsg = `${error.status} - ${error.statusText || ''}`;
        }
        else {
            errMsg = error.message ? error.message : error.toString();
        }
  
        console.error(errMsg);
        return throwError(errMsg);
    }
  
    protected ObterHeaderJson() {
      return {
          headers: new HttpHeaders({
              'Content-Type': 'application/json'

          })
      };
  }
}
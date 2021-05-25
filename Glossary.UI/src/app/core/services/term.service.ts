import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Term } from '../models/term';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class TermService extends BaseService {
 
  public listTerms(): Observable<Term[]> {
    return this.httpClient.get<Term[]>
      (`${this.APIEndpoint}terms`);
  }
}

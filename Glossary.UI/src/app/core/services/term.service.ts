import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Term } from "../models/term";
import { BaseService } from "./base.service";

@Injectable({
  providedIn: "root",
})
export class TermService extends BaseService {
  public listTerms(): Observable<Term[]> {
    return this.httpClient.get<Term[]>(`${this.APIEndpoint}terms`);
  }
  public listTermsBy(name: string, id: number = 0): Observable<Term[]> {
    return this.httpClient.get<Term[]>(
      `${this.APIEndpoint}terms/${name}/${id}`
    );
  }
  public getTermBy(id: number): Observable<Term> {
    return this.httpClient.get<Term>(`${this.APIEndpoint}terms/${id}`);
  }
  public createTerm(term: any): Observable<Term> {
    return this.httpClient.post<Term>(`${this.APIEndpoint}terms`, term);
  }
  public updateTerm(id: number, term: any): Observable<any> {
    return this.httpClient.put(`${this.APIEndpoint}terms/${id}`, term);
  }
  public deleteTerm(id: number): Observable<any> {
    return this.httpClient.delete(`${this.APIEndpoint}terms/${id}`);
  }
}

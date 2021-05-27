import { HttpErrorResponse } from "@angular/common/http";
import {  TestBed } from "@angular/core/testing";
 
import { of, throwError } from "rxjs";
import { Term } from "../models/term";
import { defer } from 'rxjs';

import { TermService } from "./term.service";

describe("TermService", () => {
  let service: TermService;
 
  let httpClientSpy: { get: jasmine.Spy, post: jasmine.Spy,put : jasmine.Spy ,delete : jasmine.Spy};
  beforeEach(() => {
    TestBed.configureTestingModule({});
    httpClientSpy = jasmine.createSpyObj("HttpClient", ["get","post","put","delete"]);
     service = new TermService(httpClientSpy as any);
  });

  it("should be created", () => {
    expect(service).toBeTruthy();
  });
  describe('#listTerms', () => {
    it("should return expected terms (HttpClient called once)", (done: DoneFn) => {
      const expectedTerms: Term[] = [
        { termId: 1, name: "first test", definition: "test definition" },
        { termId: 1, name: "second test", definition: "test definition" },
      ];
  
      httpClientSpy.get.and.returnValue(of(expectedTerms));
      service.listTerms().subscribe((terms) => {
        expect(terms).toEqual(expectedTerms, "expected terms");
        done();
      }, done.fail);
      expect(httpClientSpy.get.calls.count()).toBe(1, "one call");
    });  
  })
  describe('#getTermBy', () => {
    it("should return expected terms (HttpClient called once)", (done: DoneFn) => {
      const expectedTerm: Term = { termId: 1, name: "first test", definition: "test definition" }    
      httpClientSpy.get.and.returnValue(of(expectedTerm));
      service.getTermBy(1).subscribe((terms) => {
        expect(terms).toEqual(expectedTerm, "expected term");
        done();
      }, done.fail);
      expect(httpClientSpy.get.calls.count()).toBe(1, "one call");
    });  
    it('should return an error when the server returns a 404', (done: DoneFn) => {
      const errorResponse = new HttpErrorResponse({
        error: 'test 404 error',
        status: 404, statusText: 'Not Found'
      });    
      httpClientSpy.get.and.returnValue(throwError(errorResponse));
        service.getTermBy(1).subscribe(
        term => done.fail('expected an error, not term'),
        error  => {
          expect(error.error).toContain('test 404 error');
          done();
        }
      );
    });
  })
 
  describe('#createTerm', () => {
    it('should return an error when the server returns a 400', (done: DoneFn) => {
      const errorResponse = new HttpErrorResponse({
        error: 'Bad Request',
        status: 400, statusText: 'Bad Request'
      });  
      httpClientSpy.post.and.returnValue(throwError(errorResponse));
        service.createTerm({}).subscribe(
        term => done.fail('expected an error, not terms'),
        error  => {
          expect(error.status).toEqual(400);
          done();
        }
      );
    });
  })
  describe('#updateTerm', () => {
    it('should return an error when the server returns a 400', (done: DoneFn) => {
      const errorResponse = new HttpErrorResponse({
        error: 'Bad Request',
        status: 400, statusText: 'Bad Request'
      });  
      httpClientSpy.put.and.returnValue(throwError(errorResponse));
        service.updateTerm(1,{}).subscribe(
        term => done.fail('expected an error, not terms'),
        error  => {
          expect(error.status).toEqual(400);
          done();
        }
      );
    });
  })
  describe('#deleteTerm', () => {
    it('should return an error when the server returns a 400', (done: DoneFn) => {
      const errorResponse = new HttpErrorResponse({
        error: 'Bad Request',
        status: 400, statusText: 'Bad Request'
      });  
      httpClientSpy.delete.and.returnValue(throwError(errorResponse));
        service.deleteTerm(1).subscribe(
        term => done.fail('expected an error, not terms'),
        error  => {
          expect(error.status).toEqual(400);
          done();
        }
      );
    });
  })
  
});
 


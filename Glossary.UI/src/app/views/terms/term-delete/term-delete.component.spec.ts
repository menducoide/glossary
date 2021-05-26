import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TermDeleteComponent } from './term-delete.component';

describe('TermDeleteComponent', () => {
  let component: TermDeleteComponent;
  let fixture: ComponentFixture<TermDeleteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TermDeleteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TermDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

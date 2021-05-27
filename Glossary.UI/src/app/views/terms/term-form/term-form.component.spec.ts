import { async, ComponentFixture, TestBed } from "@angular/core/testing";
import { SharedModule } from "src/app/shared/shared.module";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { TermFormComponent } from "./term-form.component";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AppRoutingModule } from "src/app/app-routing.module";
import { MatInputModule } from "@angular/material/input";
import { FormBuilder, FormsModule, NG_VALUE_ACCESSOR, ReactiveFormsModule } from "@angular/forms";
import { forwardRef } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { TermValidator } from "src/app/core/validators/term.validator";

describe("TermFormComponent", () => {
  let component: TermFormComponent;
  let fixture: ComponentFixture<TermFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
          HttpClientModule    
      ],
      declarations: [TermFormComponent],
      providers: [
        {
          provide: MatDialogRef,
          useValue: {},
        },
        {
          provide: FormBuilder ,
          useValue: {},
        },
        {
          provide: TermValidator ,
          useValue: {},
        },
        {
          provide: MAT_DIALOG_DATA,
          useValue: {},
        },
        {
          provide: NG_VALUE_ACCESSOR,
          useExisting: forwardRef(() => TermFormComponent)
        }
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TermFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});

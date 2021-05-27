import { Component, Inject, Input, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Term } from "src/app/core/models/term";
import { TermService } from "src/app/core/services/term.service";
import { TermValidator } from "src/app/core/validators/term.validator";

@Component({
  selector: "app-term-form",
  templateUrl: "./term-form.component.html",
  styleUrls: ["./term-form.component.scss"],
})
export class TermFormComponent implements OnInit {
  errors: any = {};
  @Input() termId: number | null = null;
  constructor(
    public dialogRef: MatDialogRef<TermFormComponent>,   
    private fb: FormBuilder,
    private termService: TermService,
    private termValidator: TermValidator
  ) {}

  formGroup: FormGroup;
  async ngOnInit() {
    if (this.termId) {
      let term = await this.termService.getTermBy(this.termId).toPromise();
      this.formGroup = this.fb.group({
        termId: this.termId,
        name: [
          term.name,
          [Validators.required],
          this.termValidator.validField.bind(this),
        ],
        definition: [term.definition, [Validators.required]],
      });
    } else {
      this.formGroup = this.fb.group({
        name: [
          "",
          [Validators.required],
          this.termValidator.validField.bind(this),
        ],
        definition: ["", [Validators.required]],
      });
    }
  }
  handleOnChange(formControlName) {
    let controlErrors = this.formGroup.controls[formControlName]?.errors;
    if (controlErrors) {
      if (controlErrors.required)
        this.errors[formControlName] = "This field is required";
      else if (controlErrors.notUnique)
        this.errors[formControlName] = "This field should be unique";
    }
  }

  async onSave() {
    if (this.formGroup.valid == true) {
      if (this.termId) {
        await this.termService
          .updateTerm(this.termId, this.formGroup.value)
          .toPromise();
      } else {
        await this.termService.createTerm(this.formGroup.value).toPromise();
      }
      this.dialogRef.close(true);
    }
  }
  onCancel() {
    this.dialogRef.close(false);
  }
}

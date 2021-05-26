import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-form-field',
  templateUrl: './form-field.component.html',
  styleUrls: ['./form-field.component.scss']
})
export class FormFieldComponent implements OnInit {
  @Input() label: string;
  @Input() placeholder: string = "";
  @Input() formGroup: FormGroup;
  @Input() formControlName: string;
  @Input() hint: string | null = null;
  @Input() required: boolean = false;
  @Input() invalidMessage : string | null = null;
  @Output() handleOnChange: EventEmitter<any> = new EventEmitter<any>();
  constructor() { }

  ngOnInit(): void {
  }
  onChange(event){
     this.handleOnChange.emit(this.formControlName);
  }

}

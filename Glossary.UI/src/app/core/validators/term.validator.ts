import { AbstractControl, ValidationErrors } from '@angular/forms'
import { Injectable } from '@angular/core';
import { TermService } from '../services/term.service';

@Injectable()
export class TermValidator {
    constructor(private termService: TermService) { }
    validField(control: AbstractControl): ValidationErrors | null {
        if (!control || !control.value) return null;
        return new Promise<ValidationErrors | null>(resolve => {
            let id : number = 0;
            if (control && control.parent && control.parent.controls['termId']) {
                id = Number(control.parent.controls['termId'].value);
            }
            this.termService.listTermsBy(control.value, id).subscribe(r => {
                resolve(!r || r.length == 0 ? null : { "notUnique": true });
            })
        });
    }
}
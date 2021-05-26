import { Component, Input, OnInit } from "@angular/core";
import { MatDialogRef } from "@angular/material/dialog";
import { TermService } from "src/app/core/services/term.service";

@Component({
  selector: "app-term-delete",
  templateUrl: "./term-delete.component.html",
  styleUrls: ["./term-delete.component.scss"],
})
export class TermDeleteComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<TermDeleteComponent>,
    private termService: TermService
  ) {}
  @Input() termId: number;
  @Input() name: string;
  ngOnInit(): void {}
  async onSave() {
    await this.termService.deleteTerm(this.termId).toPromise();
    this.dialogRef.close(true);
  }
  onCancel() {
    this.dialogRef.close(false);
  }
}

import {
  Component,
  OnInit,
  OnDestroy,
  ViewChild,
  ChangeDetectorRef,
} from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { TableComponent } from "src/app/components/table/table.component";
import { ActionColumn } from "src/app/core/models/common/action-column ";
import { SortableColumn } from "src/app/core/models/common/sortable-column";
import { Term } from "src/app/core/models/term";
import { TermService } from "src/app/core/services/term.service";
import { TermFormComponent } from "../term-form/term-form.component";

@Component({
  selector: "app-terms-list",
  templateUrl: "./terms-list.component.html",
  styleUrls: ["./terms-list.component.scss"],
})
export class TermsListComponent implements OnInit, OnDestroy {
  terms: Term[];
  termsColumns: SortableColumn[];
  actionColumns: ActionColumn[];
  constructor(
    public dialog: MatDialog,
    private termService: TermService,
    private cd: ChangeDetectorRef
  ) {}
  ngOnDestroy(): void {
    
  }
  async ngOnInit() {
    await this.populateTerms();
  }
  async populateTerms() {
    this.termsColumns = [
      { label: "Term", colDef: "name" },
      { label: "Definition", colDef: "definition" },
    ];
    this.actionColumns = [
      { label: "Edit", actionDef: "edit" },
      { label: "Delete", actionDef: "delete" },
    ];
    this.terms = await this.termService.listTerms().toPromise();
  }
  handleOnActionClick(event) {
     switch (event.actionDef) {
      case "edit": {
        this.onEdit(event.element.termId);
        break;
      }
      case "delete": {
        break;
      }
      default:
        break;
    }
  }
  onCreate() {
    this.openTermDialog();
  }
  onEdit(termId: number) {
    this.openTermDialog(termId);
  }

  openTermDialog = (termId: number | null = null): void => {
    const dialogRef = this.dialog.open(TermFormComponent, {
      width: "500px",
      height: "500px",
    });
    if (termId) {
      dialogRef.componentInstance.termId = termId;
    }
    dialogRef.afterClosed().subscribe(async (result) => {
      if (result == true) {       
        await this.populateTerms();
      }
    });
  };
}

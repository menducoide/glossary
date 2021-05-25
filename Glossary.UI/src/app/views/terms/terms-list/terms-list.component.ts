import { Component, OnInit, OnDestroy } from "@angular/core";
import { ActionColumn } from "src/app/core/models/common/action-column ";
import { SortableColumn } from "src/app/core/models/common/sortable-column";
import { Term } from "src/app/core/models/term";
import { TermService } from "src/app/core/services/term.service";

@Component({
  selector: "app-terms-list",
  templateUrl: "./terms-list.component.html",
  styleUrls: ["./terms-list.component.scss"],
})
export class TermsListComponent implements OnInit, OnDestroy {
  terms: Term[];
  termsColumns: SortableColumn[];
  actionColumns: ActionColumn[];
  constructor(private termService: TermService) {}
  ngOnDestroy(): void {}
  async ngOnInit() {
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
  handleOnActionClick(event){
    console.log(event);
  }
}

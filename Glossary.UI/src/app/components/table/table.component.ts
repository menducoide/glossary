import {
  AfterViewInit,
  Component,
  Input,
  ViewChild,
  OnInit,
  Output,
  EventEmitter,
  OnChanges,
  SimpleChanges,
} from "@angular/core";
import { MatSort } from "@angular/material/sort";
import { MatTable, MatTableDataSource } from "@angular/material/table";
import { ActionColumn } from "src/app/core/models/common/action-column ";
import { SortableColumn } from "src/app/core/models/common/sortable-column";

@Component({
  selector: "app-table",
  templateUrl: "./table.component.html",
  styleUrls: ["./table.component.scss"],
})
export class TableComponent implements AfterViewInit, OnInit, OnChanges {
  @Input() data: any[];
  @Input() sortableColumns: SortableColumn[];
  @Input() actionColumns: ActionColumn[] = [];
  @Output() handleOnActionClick: EventEmitter<any> = new EventEmitter<any>();
  displayedColumns: string[];
  dataSource: MatTableDataSource<any>;
  menuIcon: string = "more_vert";
  constructor() {}
  ngOnChanges(changes: SimpleChanges): void {
    this.ngOnInit();
  }
  ngOnInit(): void {
    this.dataSource = new MatTableDataSource(this.data);
    if (this.sortableColumns) {
      this.displayedColumns = this.sortableColumns.map((s) => s.colDef);
    }else{
      this.displayedColumns  = new Array<string>();
    }
    if (this.actionColumns) {
      this.displayedColumns.push("action");
    }
  }

  @ViewChild(MatSort) sort: MatSort;
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
  }
  onActionClick(actionDef: string, element) {
    this.handleOnActionClick.emit({ actionDef, element });
  }
}

import { Component, OnInit } from "@angular/core";
 import { MenuItem } from "src/app/core/models/common/menu-item";
 
@Component({
  selector: "app-layout",
  templateUrl: "./layout.component.html",
  styleUrls: ["./layout.component.scss"],
})
export class LayoutComponent implements OnInit {
  constructor() {}
  title: string;
  menuItems: MenuItem[];
   ngOnInit(): void {
    this.title = "Glossary";
    this.menuItems = [
      { url: "terms", label: "Terms", icon: 'home' },
     ];
 
  }
}

import { CommonModule } from '@angular/common';
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations"; 
 import { MaterialModule } from "./material.module";
import { RouterModule } from "@angular/router";
import { TableComponent } from '../components/table/table.component';

@NgModule({
  declarations: [ 
    TableComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,   
    ReactiveFormsModule,
    FormsModule,
    MaterialModule,
    HttpClientModule
   ],
   exports : [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,    
    ReactiveFormsModule,
    FormsModule,
    MaterialModule,  
    HttpClientModule,
    TableComponent
    ],
  providers: [],
  })
export class SharedModule {}

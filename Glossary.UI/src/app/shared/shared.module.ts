import { CommonModule } from '@angular/common';
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations"; 
 import { MaterialModule } from "./material.module";
import { RouterModule } from "@angular/router";
import { TableComponent } from '../components/table/table.component';
import { FormFieldComponent } from '../components/form-field/form-field.component';
import { TermValidator } from '../core/validators/term.validator';

 
@NgModule({
  declarations: [ 
    TableComponent,
    FormFieldComponent
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
    TableComponent,
    FormFieldComponent
    ],
  providers: [TermValidator],
  })
export class SharedModule {}

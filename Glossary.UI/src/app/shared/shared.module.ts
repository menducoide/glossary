import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations"; 
 import { MaterialModule } from "./material.module";
import { RouterModule } from "@angular/router";
 
@NgModule({
  declarations: [ 
    
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,   
    ReactiveFormsModule,
    FormsModule,
    MaterialModule
   ],
   exports : [
    BrowserModule,
    BrowserAnimationsModule,    
    ReactiveFormsModule,
    FormsModule,
    MaterialModule,  
    ],
  providers: [],
  })
export class SharedModule {}

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { LayoutComponent } from "./views/layout/layout.component";
import { TermsListComponent } from './views/terms/terms-list/terms-list.component';
import { TermFormComponent } from './views/terms/term-form/term-form.component';
 
import { SharedModule } from "./shared/shared.module";


@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    TermsListComponent,
    TermFormComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

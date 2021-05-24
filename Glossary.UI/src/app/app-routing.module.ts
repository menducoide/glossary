import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TermsListComponent } from './views/terms/terms-list/terms-list.component';


const routes: Routes = [
  {path: 'terms', component: TermsListComponent},
   {path: '**', redirectTo:"terms",}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

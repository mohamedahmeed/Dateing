import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GurdeGuard } from 'src/gurde.guard';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MassagesComponent } from './massages/massages.component';
import { MemberDetailsComponent } from './Members/member-details/member-details.component';
import { MemberListComponent } from './Members/member-list/member-list.component';

const routes: Routes = [
  {path:"Home",component:HomeComponent},
  {path:"Member",component:MemberListComponent},
  {path:"Member:/id",component:MemberDetailsComponent},
  {path:"Massage",component:MassagesComponent},
  {path:"List",component:ListsComponent,canActivate:[GurdeGuard]},
  {path:"**",component:HomeComponent,pathMatch:"full"},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

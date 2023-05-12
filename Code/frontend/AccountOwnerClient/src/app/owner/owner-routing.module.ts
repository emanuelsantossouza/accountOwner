import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { OwnerUpdateComponent } from './owner-update/owner-update.component';
import { OwnerListComponent } from './owner-list/owner-list.component';
import { OwnerDetailsComponent } from './owner-details/owner-details.component';
import { OwnerCreateComponent } from './owner-create/owner-create.component';

const routes: Routes = [
  { path: 'list', component: OwnerListComponent },
  { path: 'details/:id', component: OwnerDetailsComponent },
  { path: 'create', component: OwnerCreateComponent },
  { path: 'update/:id', component: OwnerUpdateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OwnerRoutingModule { }

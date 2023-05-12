import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OwnerRoutingModule } from './owner-routing.module';
import { OwnerListComponent } from './owner-list/owner-list.component';
import { OwnerDetailsComponent } from './owner-details/owner-details.component';
import { OwnerCreateComponent } from './owner-create/owner-create.component';


import { ReactiveFormsModule } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { OwnerAccountsComponent } from './owner-details/owner-accounts/owner-accounts.component';
import { SharedModule } from '../shared/shared.module';
import { OwnerUpdateComponent } from './owner-update/owner-update.component';


@NgModule({
  declarations: [
    OwnerListComponent,
    OwnerDetailsComponent,
    OwnerCreateComponent,
    OwnerAccountsComponent,
    OwnerUpdateComponent
    
  ],
  imports: [
    CommonModule,
    OwnerRoutingModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot(),
    SharedModule

  ]
})
export class OwnerModule { }

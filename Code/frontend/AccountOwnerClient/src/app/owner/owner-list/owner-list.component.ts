import { OwnerRepositoryService } from 'src/app/shared/services/owner-repository.service';
import { Owner } from './../../_interfaces/owner.model';
import { Component } from '@angular/core';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-owner-list',
  templateUrl: './owner-list.component.html',
  styleUrls: ['./owner-list.component.css']
})
export class OwnerListComponent {
  owners: Owner[];
  errorMessage: string = '';

  constructor(private repository: OwnerRepositoryService, private errorHandles: ErrorHandlerService, private router: Router) { }

  ngOnInit(): void {
    this.getAllOwners();
  }

  private getAllOwners = () => {
    const apiAddress: string = 'api/owner';
    this.repository.getOwners(apiAddress).subscribe({
      next: (own: Owner[]) => this.owners = own,
      error: (err: HttpErrorResponse) => {
        this.errorHandles.handleError(err);
        this.errorMessage = this.errorHandles.errorMessage;
      }
    })
  }

  public getOwnerDetails = (id) => {
    const detailsUrl: string = `/owner/details/${id}`;
    this.router.navigate([detailsUrl]);
  }

  public redirectToUpdatePage = (id) => {
    const updateUrl: string = `/owner/update/${id}`;
    this.router.navigate([updateUrl]);
  }

}

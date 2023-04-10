import { OwnerRepositoryService } from 'src/app/shared/services/owner-repository.service';
import { Owner } from './../../_interfaces/owner.model';
import { Component } from '@angular/core';

@Component({
  selector: 'app-owner-list',
  templateUrl: './owner-list.component.html',
  styleUrls: ['./owner-list.component.css']
})
export class OwnerListComponent {
  owners: Owner[];

  constructor(private repository: OwnerRepositoryService) { }

  ngOnInit(): void {
    this.getAllOwners();
  }

  private getAllOwners = () => {
    const apiAddress: string = 'api/owner';
    this.repository.getOwners(apiAddress).subscribe(own => {
      this.owners = own;
    })
  }

}

import { Component } from '@angular/core';
import { NgFor } from '@angular/common';

import { CustomerListService } from './customer-list.service';

@Component({
  selector: 'app-customer-list',
  standalone: true,
  templateUrl: './customer-list.component.html',
  styleUrl: './customer-list.component.css',
  imports: [
    NgFor
  ]
})

export class CustomerListComponent {
  customers : string[] = [
    "Lena Oxton",
    "Jack Morrison",
    "Genji Shimada",
    "Hanzo Shimada"
  ];

  constructor(private service: CustomerListService) { }

  ngOnInit(): void {
    this.service.getCustomers().subscribe(data => this.customers = data)
  }
}

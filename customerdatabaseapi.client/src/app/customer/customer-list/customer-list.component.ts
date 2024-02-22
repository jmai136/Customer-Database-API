import { Component } from '@angular/core';
import { NgFor } from '@angular/common';

import { CustomerListService } from './customer-list.service';
import { Customer } from '../customer';

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
  customers : Customer[] = [
  ];

  constructor(private service: CustomerListService) { }

  ngOnInit(): void {
    this.service.getCustomers().subscribe(data => this.customers = data)
  }

  getCustomers(): void {

  }
}

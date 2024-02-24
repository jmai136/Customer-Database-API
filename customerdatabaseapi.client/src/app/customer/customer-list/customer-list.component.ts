import { Component } from '@angular/core';
import { NgFor, NgIf, UpperCasePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { CustomerListService } from './customer-list.service';
import { Customer } from '../customer';

import { PersonListComponent } from '../../person/person-list/person-list.component';

@Component({
  selector: 'app-customer-list',
  standalone: true,
  templateUrl: './customer-list.component.html',
  styleUrl: './customer-list.component.css',
  imports: [
    NgFor,
    NgIf,
    UpperCasePipe,
    FormsModule,

    PersonListComponent
  ]
})

export class CustomerListComponent {
  // Honestly customer-list and customer-crud should just be one module
  private readonly apiUrl = '/api/customers';

  selectedCustomer?: Customer;
  selectedCustomerID?: number;

  customers: Customer[] = [
  ];

  constructor(private service: CustomerListService) { }

  ngOnInit(): void {
    this.getCustomers();
  }

  getCustomers(): void {
    this.service.getCustomers().subscribe((data : Customer[]) => this.customers = data);
  }

  onSelectCustomer(customerID : number): void {
    this.selectedCustomerID = customerID;
    this.getCustomer(this.selectedCustomerID);
  }

  getCustomer(id: number): void {
    this.service.getCustomer(id).subscribe((customer: Customer) => this.selectedCustomer = customer);
  }
}

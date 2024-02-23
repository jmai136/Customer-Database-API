import { Component } from '@angular/core';

import { CustomerCrudService } from './customer-crud.service';
import { Customer } from '../customer';

@Component({
  selector: 'app-customer-crud',
  standalone: true,
  imports: [],
  templateUrl: './customer-crud.component.html',
  styleUrl: './customer-crud.component.css'
})
export class CustomerCrudComponent {
  constructor(private service: CustomerCrudService) { }

  // CREATE
  postCustomer(data: Customer) {
    this.service.postCustomer(data).subscribe(
      (response: Customer) => {
        console.log('Created customer:', response);
      },
      (error: any) => {
        console.error('Error creating customer:', error);
      }
    );
  }

  // UPDATE
  putCustomer(id: number, data: Customer) {
    this.service.putCustomer(id, data).subscribe(
      (response : Customer) => {
        console.log('Updated customer:', response);
      },
      (error : any) => {
        console.error('Error updating customer:', error);
      }
    );
  }

  // Method to delete a customer
  deleteCustomer(id: number) {
    this.service.deleteCustomer(id).subscribe(
      (response) => {
        // Handle success
        console.log('Customer deleted successfully:', response);
      },
      (error) => {
        // Handle error
        console.error('Error deleting customer:', error);
      }
    );
  }
};

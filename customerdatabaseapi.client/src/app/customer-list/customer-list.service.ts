import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerListService {
  constructor(private http: HttpClient) { }

  private readonly apiUrl = '/api/customers'

  // Replace any with Customer[]
  getCustomers(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  /*
  getCustomer(id : int) {

  }

  // Post
  postCustomer(customer: Customer) {

  }

  deleteCustomer(id: int) {

  }

  customerExists(int : id) {

  }*/
}

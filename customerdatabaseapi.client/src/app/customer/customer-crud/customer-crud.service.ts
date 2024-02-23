import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerCrudService {
  constructor(private http: HttpClient) { }

  private readonly apiUrl = '/api/Customers';

  // CREATE - Replace any with Customer[]
  postCustomer(data : Customer): Observable<Customer> {
    return this.http.post<Customer>(this.apiUrl, data);
  }

  // UPDATE
  putCustomer(id: number, data: Customer): Observable<Customer> {
    return this.http.put<Customer>(this.apiUrl, data);
  }

  // DELETE
  deleteCustomer(id: number): Observable<any> {
    return this.http.delete<any>(this.apiUrl.concat("/", id.toString()));
  }
}

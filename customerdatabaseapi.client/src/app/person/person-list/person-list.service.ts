import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../person';

@Injectable({
  providedIn: 'root'
})
export class PersonListService {
  constructor(private http: HttpClient) { }

  private readonly apiUrl = '/api/People';

  getPersons(): Observable<Person[]> {
    return this.http.get<Person[]>(this.apiUrl);
  }

  getPerson(id: number): Observable<Person> {
    return this.http.get<Person>(this.apiUrl.concat("/", id.toString()));
  }
}

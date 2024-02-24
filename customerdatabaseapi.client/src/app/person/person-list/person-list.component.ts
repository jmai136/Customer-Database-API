import { Component, Input } from '@angular/core';
import { TitleCasePipe } from '@angular/common';

import { PersonListService } from '../../person/person-list/person-list.service';
import { Person } from '../../person/person';

@Component({
  selector: 'app-person-list',
  standalone: true,
  imports: [TitleCasePipe],
  templateUrl: './person-list.component.html',
  styleUrl: './person-list.component.css'
})
export class PersonListComponent {
  constructor(private service: PersonListService) { }

  @Input() personId?: number;

  person?: Person;

  persons: Person[] = [
  ];

  ngOnChanges(): void {
    if (this.personId) {
      this.getPerson(this.personId);
    }
  }

  // Overload this
  getPerson(id: number): void {
    this.service.getPerson(id).subscribe((person: Person) => this.person = person);
  }
}

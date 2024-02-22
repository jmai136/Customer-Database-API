import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomerCrudComponent } from './customer-crud.component';

describe('CustomerCrudComponent', () => {
  let component: CustomerCrudComponent;
  let fixture: ComponentFixture<CustomerCrudComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CustomerCrudComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CustomerCrudComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

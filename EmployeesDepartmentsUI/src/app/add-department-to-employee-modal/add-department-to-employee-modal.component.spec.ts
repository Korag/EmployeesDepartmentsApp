import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDepartmentToEmployeeModalComponent } from './add-department-to-employee-modal.component';

describe('AddDepartmentToEmployeeModalComponent', () => {
  let component: AddDepartmentToEmployeeModalComponent;
  let fixture: ComponentFixture<AddDepartmentToEmployeeModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddDepartmentToEmployeeModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDepartmentToEmployeeModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { Component, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddDepartmentModalComponent } from './add-department-modal/add-department-modal.component';
import { AddEmployeeModalComponent } from './add-employee-modal/add-employee-modal.component';
import { EmployeesListComponent } from './employees-list/employees-list.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'EmployeesDepartmentsUI';
  @ViewChild(EmployeesListComponent) employeesList!: EmployeesListComponent;

  constructor(private modalService: NgbModal) {

  }

  async ngOnInit(): Promise<void> {

  }

  async openAddEmployeeModal(): Promise<void> {
    const modalRef = this.modalService.open(AddEmployeeModalComponent,
      {
        scrollable: true,
        keyboard: false,
        backdrop: 'static',
        centered: false,
        size: "modal-lg"
      });
    modalRef.componentInstance.addEmployeeEvent.subscribe(($e: any) => {
      this.employeesList.ngOnInit();
    });
  }

  async openAddDepartmentModal(): Promise<void> {
    const modalRef = this.modalService.open(AddDepartmentModalComponent,
      {
        scrollable: true,
        keyboard: false,
        backdrop: 'static',
        centered: false,
        size: "modal-lg"
      });
    modalRef.componentInstance.addDepartmentEvent.subscribe(($e: any) => {
      this.employeesList.ngOnInit();
    });
  }
}

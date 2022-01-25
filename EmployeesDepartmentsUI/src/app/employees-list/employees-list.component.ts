import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddDepartmentToEmployeeModalComponent } from '../add-department-to-employee-modal/add-department-to-employee-modal.component';
import { Department, Employee } from '../Models';
import { ApiContextService } from '../Services/api-context.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {
  public employees!: Array<Employee>;
  public allDepartments!: Array<Department>;

  constructor(private context: ApiContextService, private modalService: NgbModal) { }

  async ngOnInit(): Promise<void> {
    this.employees = await this.context.getEmployeesWithDepartments();
    this.allDepartments = await this.context.getDepartments();
  }

  async removeDepartmentFromEmployee(employee: Employee, department: Department): Promise<void> {
    var employeeIndex = this.employees.findIndex((z) => z.employeeId === employee.employeeId);
    this.employees[employeeIndex].departments = this.employees[employeeIndex].departments?.filter((z) => z.departmentId != department.departmentId);

    await this.context.removeDepartmentFromEmployee(employee.employeeId!, department.departmentId!);
  }

  async addDepartmentToEmployee(employee: Employee): Promise<void>{

    const modalRef = this.modalService.open(AddDepartmentToEmployeeModalComponent,
      {
        scrollable: true,
        keyboard: false,
        backdrop: 'static',
        centered: false,
        size: "modal-lg"
      });
    modalRef.componentInstance.employee = employee;
    modalRef.componentInstance.addDepartmentToEmployeeEvent.subscribe(($e: any) => {
      this.ngOnInit();
    });
  }
}

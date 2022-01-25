import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Department, Employee } from '../Models';
import { ApiContextService } from '../Services/api-context.service';

@Component({
  selector: 'app-add-department-to-employee-modal',
  templateUrl: './add-department-to-employee-modal.component.html',
  styleUrls: ['./add-department-to-employee-modal.component.css']
})
export class AddDepartmentToEmployeeModalComponent implements OnInit {
  @Output() addDepartmentToEmployeeEvent = new EventEmitter<any>();
  @Input() employee!: Employee;

  departments!: Array<Department>;

  constructor(
    private context: ApiContextService,
    private activeModal: NgbActiveModal,
    private formBuilder: FormBuilder) { }

  addDepartmentToEmployeeForm!: FormGroup;
  loading = false;

  async ngOnInit(): Promise<void> {
    this.addDepartmentToEmployeeForm = this.formBuilder.group({
      departmentId: [{ value: "", disabled: false }]
    })

    this.departments = await this.context.getDepartments();

    for (let index = 0; index < this.employee.departments!.length; index++) {
      const element = this.employee.departments![index];

      this.departments = this.departments.filter((z) => z.departmentId != element.departmentId);
    }
  }

  closeModal(): void {
    this.activeModal.close();
  }

  public get f() { return this.addDepartmentToEmployeeForm.controls; }

  async addDepartmentToEmployee(): Promise<void> {
    this.loading = true;

    await this.context.addDepartmentToEmployee(this.employee.employeeId!, this.f.departmentId.value);
    this.addDepartmentToEmployeeEvent.emit();
    this.closeModal();

    this.loading = false;
  }
}

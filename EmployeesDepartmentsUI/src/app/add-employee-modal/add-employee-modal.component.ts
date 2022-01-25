import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Employee } from '../Models';
import { ApiContextService } from '../Services/api-context.service';

@Component({
  selector: 'app-add-employee-modal',
  templateUrl: './add-employee-modal.component.html',
  styleUrls: ['./add-employee-modal.component.css']
})
export class AddEmployeeModalComponent implements OnInit {
  @Output() addEmployeeEvent = new EventEmitter<any>();

  constructor(
    private context: ApiContextService,
    private activeModal: NgbActiveModal,
    private formBuilder: FormBuilder) { }

    createEmployeeForm!: FormGroup;
    loading = false;
    submitted = false;

    async ngOnInit(): Promise<void> {
      this.createEmployeeForm = this.formBuilder.group({
        firstName: [{ value: "", disabled: false }, Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(100)])],
        lastName: [{ value: "", disabled: false }, Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(100)])],
        emailAddress: [{ value: "", disabled: false }, Validators.compose([Validators.required, Validators.email, Validators.minLength(2), Validators.maxLength(100)])],
        age: [{ value: "", disabled: false }, Validators.compose([Validators.required, Validators.min(1), Validators.max(120)])],
        role: [{ value: "", disabled: false }, Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(100)])],
        sex: [{ value: "", disabled: false }, Validators.compose([Validators.required, Validators.minLength(1), Validators.maxLength(1)])],
      })
    }

    public get f() { return this.createEmployeeForm.controls; }

    closeModal(): void{
      this.activeModal.close();
    }

    async addNewEmployee(): Promise<void>{
      this.submitted = true;
      this.loading = true;
  
      try {
        var employee = new Employee();
        employee.firstName = this.f.firstName.value;
        employee.lastName = this.f.lastName.value;
        employee.emailAddress = this.f.emailAddress.value;
        employee.age = this.f.age.value;
        employee.role = this.f.role.value;
        employee.sex = this.f.sex.value;

        var createdEmployee = await this.context.createEmployee(employee);
  
        if (createdEmployee) {
          this.addEmployeeEvent.emit();
          this.closeModal();
        }
      } catch (err) {
        }
  
      this.loading = false;
    }
}

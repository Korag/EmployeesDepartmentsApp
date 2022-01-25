import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Department } from '../Models';
import { ApiContextService } from '../Services/api-context.service';

@Component({
  selector: 'app-add-department-modal',
  templateUrl: './add-department-modal.component.html',
  styleUrls: ['./add-department-modal.component.css']
})
export class AddDepartmentModalComponent implements OnInit {
  @Output() addDepartmentEvent = new EventEmitter<any>();

  constructor(
    private context: ApiContextService,
    private activeModal: NgbActiveModal,
    private formBuilder: FormBuilder) { }

  createDepartmentForm!: FormGroup;
  loading = false;
  submitted = false;

  async ngOnInit(): Promise<void> {
    this.createDepartmentForm = this.formBuilder.group({
      name: [{ value: "", disabled: false }, Validators.compose([Validators.required, Validators.minLength(2), Validators.maxLength(100)])],
    })
  }

  public get f() { return this.createDepartmentForm.controls; }

  closeModal(): void{
    this.activeModal.close();
  }

  async addNewDepartment(): Promise<void>{
    this.submitted = true;
    this.loading = true;

    try {
      var department = new Department();
      department.name = this.f.name.value;
      var createdDepartment = await this.context.createDepartment(department);

      if (createdDepartment) {
        this.addDepartmentEvent.emit();
        this.closeModal();
      }
    } catch (err) {
      }

    this.loading = false;
  }
}

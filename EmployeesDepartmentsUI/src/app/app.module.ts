import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeesListComponent } from './employees-list/employees-list.component';
import { AddEmployeeModalComponent } from './add-employee-modal/add-employee-modal.component';
import { AddDepartmentModalComponent } from './add-department-modal/add-department-modal.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AddDepartmentToEmployeeModalComponent } from './add-department-to-employee-modal/add-department-to-employee-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeesListComponent,
    AddEmployeeModalComponent,
    AddDepartmentModalComponent,
    AddDepartmentToEmployeeModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

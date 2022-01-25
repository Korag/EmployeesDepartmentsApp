import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Department, Employee } from '../Models';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiContextService {

  constructor(private http: HttpClient) { }

  public async createEmployee(employee: Employee): Promise<Employee> {
    var createdEmployee = new Employee();

    await this.http.post<Employee>(`${environment.apiUrl}/Employee`, { firstName: employee.firstName, lastName: employee.lastName, emailAddress: employee.emailAddress, age: employee.age, role: employee.role, sex: employee.sex })
      .pipe(map(result => {
        createdEmployee = result;
      })).toPromise();

    return await createdEmployee;
  }

  public async createDepartment(department: Department): Promise<Department> {
    var createdDepartment = new Department();

    await this.http.post<Department>(`${environment.apiUrl}/Department`, { name: department.name })
      .pipe(map(result => {
        createdDepartment = result;
      })).toPromise();

    return await createdDepartment;
  }

  public async getEmployeesWithDepartments(): Promise<Array<Employee>> {
    var employees = new Array<Employee>();

    await this.http.get<Array<Employee>>(`${environment.apiUrl}/DepartmentEmployee`, {})
      .pipe(map(result => {
        employees = result;
      })).toPromise();

    return await employees;
  }

  public async getDepartments(): Promise<Array<Department>> {
    var departments = new Array<Department>();

    await this.http.get<Array<Department>>(`${environment.apiUrl}/Department`, {})
      .pipe(map(result => {
        departments = result;
      })).toPromise();

    return await departments;
  }

  public async removeDepartmentFromEmployee(employeeId: number, departmentId: number): Promise<void> {
      await this.http.delete(`${environment.apiUrl}/DepartmentEmployee`, { body: { employeeId: employeeId, departmentId: departmentId } }).toPromise();
  }

  public async addDepartmentToEmployee(employeeId: number, departmentId: number): Promise<void> {
    await this.http.post(`${environment.apiUrl}/DepartmentEmployee`, { employeeId: employeeId, departmentId: departmentId }).toPromise();
}
}

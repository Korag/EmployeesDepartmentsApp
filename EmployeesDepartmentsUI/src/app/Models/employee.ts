import { Department } from ".";

export class Employee{
    employeeId?: number;
    firstName?: string;
    lastName? : string;

    emailAddress?: string;
    age?: number;
    role?: string;
    sex?: string;

    departments?: Array<Department>;
}
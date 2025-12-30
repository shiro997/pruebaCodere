import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Employee } from 'src/app/models/employee';
import { Group } from 'src/app/models/group';
import { EventEmployee } from 'src/app/models/utils/eventEmployee';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee.form.component.html',
  styleUrls: ['./employee.form.component.css']
})
export class EmployeeFormComponent {
  @Input() Groups: Group[] = [];
  @Input() employee?: Employee;
  @Input() Employees: Employee[] =[];

  @Output() newItemEvent = new EventEmitter<EventEmployee>();

  frmEmployee: FormGroup;

  constructor(private frmBuilder: FormBuilder) {
    this.frmEmployee = this.frmBuilder.group({
      nameEmployee: ['', Validators.required],
      codeGroup: [0, Validators.required],
      salary: ['', Validators.required],
      jobTitle: ['', Validators.required],
      codeLeader: [0]
    });
  }

  ngOnChanges() {
    console.info(this.Groups);
    console.info(this.employee);
    if (this.employee) {
      this.frmEmployee = this.frmBuilder.group({
        nameEmployee: [this.employee.nameEmployee, Validators.required],
        codeGroup: [this.employee.codeGroup, Validators.required],
        salary: [this.employee.salary, Validators.required],
        jobTitle: [this.employee.jobTitle, Validators.required],
        codeLeader: [this.employee.codeLeader]
      });
      console.info(this.frmEmployee.value);
    }

  }

  resetForm(){
    this.frmEmployee = this.frmBuilder.group({
      nameEmployee: ['', Validators.required],
      codeGroup: [0, Validators.required],
      salary: ['', Validators.required],
      jobTitle: ['', Validators.required],
      codeLeader: [0]
    });
  }

  createEmployee(){
    let newEmployeeTMP = this.frmEmployee.value;
    let newEmployee = new Employee();
    newEmployee = newEmployeeTMP;
    
    let numericCodeGroup = parseInt(newEmployeeTMP.codeGroup);
    newEmployee.codeGroup = numericCodeGroup;
    let ev = new EventEmployee();
    ev.isUpdate = false;
    ev.employee = newEmployee
    this.newItemEvent.emit(ev);
    this.resetForm();
  }

  updateEmployee(){
    let ev = new EventEmployee();
    let formValue = this.frmEmployee.value;
    ev.employee = formValue;
    let numericCodeGroup = parseInt(formValue.codeGroup);
    ev.employee.codeGroup = numericCodeGroup;
    ev.isUpdate = true;
    this.newItemEvent.emit(ev);
    this.employee = undefined;
    this.resetForm();
  }
}
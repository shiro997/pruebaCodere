import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Employee } from 'src/app/models/employee';
import { Group } from 'src/app/models/group';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee.form.component.html',
  styleUrls: ['./employee.form.component.css']
})
export class EmployeeFormComponent {
  @Input() Groups: Group[] = [];
  @Input() employee!: Employee;
  @Input() Employees: Employee[] =[];

  @Output() newItemEvent = new EventEmitter<Employee>();

  frmEmployee: FormGroup;

  constructor(private frmBuilder: FormBuilder) {
    this.frmEmployee = this.frmBuilder.group({
      nameEmployee: ['', Validators.required],
      codeGroup: [0, Validators.required],
      salary: [0, Validators.required],
      jobTitle: ['', Validators.required],
      codeLeader: [0,Validators.required]
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
        codeLeader: [this.employee.codeLeader, Validators.required]
      });
      console.info(this.frmEmployee.value);
    }

  }
}
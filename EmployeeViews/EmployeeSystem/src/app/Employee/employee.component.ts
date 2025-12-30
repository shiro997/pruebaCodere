import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../service/employee.service';
import { Employee } from '../models/employee';
import { throwError } from 'rxjs';
import { Group } from '../models/group';
import { GroupService } from '../service/group.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit{
  employees:  Employee[] = [];
  groups: Group[]=[];
  formEmployeeValue!:Employee;

  constructor(private employeeSrv : EmployeeService,private groupSrv:GroupService){}

  ngOnInit(): void {
    this.employeeSrv.getEmployees().subscribe(response =>{
      if(!response){ throwError;}
      console.info(response);
      this.employees = response;
    });
    this.groupSrv.getGroups().subscribe(response =>{
      if(!response){throwError;}
      console.info(response);
      this.groups = response;
    })
  }

  editarInfo($employee: Employee){
    console.info($employee);
    this.formEmployeeValue = $employee;
  }

}
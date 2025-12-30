import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../service/employee.service';
import { Employee } from '../models/employee';
import { throwError } from 'rxjs';
import { Group } from '../models/group';
import { GroupService } from '../service/group.service';
import { EventEmployee } from '../models/utils/eventEmployee';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employees: Employee[] = [];
  groups: Group[] = [];
  formEmployeeValue!: Employee;

  constructor(private employeeSrv: EmployeeService, private groupSrv: GroupService, private toastrSrv: ToastrService) { }

  ngOnInit(): void {
    this.employeeSrv.getEmployees().subscribe(response => {
      if (!response) { throwError; }
      console.info(response);
      this.employees = response;
    });
    this.groupSrv.getGroups().subscribe(response => {
      if (!response) { throwError; }
      console.info(response);
      this.groups = response;
    })
  }

  editarInfo($employee: Employee) {
    console.info($employee);
    this.formEmployeeValue = $employee;
  }

  eliminarEmpleado($employee:Employee){
    this.employeeSrv.deleteEmployee($employee.codeEmployee).subscribe(response =>{
      if(!response){this.toastrSrv.error("no se puede eliminar el empleado intente más tarde")}
      this.toastrSrv.success("Empleado eliminado satisfactoriamente");
      this.employeeSrv.getEmployees().subscribe(response => {
          if (!response) { throwError; }
          console.info(response);
          this.employees = response;
        });
    })
  }

  capturarEventoFormulario($event: EventEmployee) {
    console.info($event);
    if (!$event.isUpdate) {
      console.info("Creando empleado");
      let groupName = this.groups.find(g => g.codeGroup == $event.employee.codeGroup)?.nameGroup;
      $event.employee.nameGroup = <string>groupName;
      $event.employee.nameLeader = "a";
      this.employeeSrv.createEmployee($event.employee).subscribe(response => {
        if (!response) { throwError; this.toastrSrv.error(response) }
        this.toastrSrv.success("Empleado creado satisfactoriamente");
        this.employeeSrv.getEmployees().subscribe(response => {
          if (!response) { throwError; }
          console.info(response);
          this.employees = response;
        });
      })
    } else {
      console.info("Actualizando empleado");
      let groupName = this.groups.find(g => g.codeGroup == $event.employee.codeGroup)?.nameGroup;
      $event.employee.nameGroup = <string>groupName;
      $event.employee.nameLeader = "a";
      $event.employee.codeEmployee = this.formEmployeeValue.codeEmployee;
      this.employeeSrv.updateEmployee($event.employee).subscribe(response => {
        if (!response) { this.toastrSrv.error("Ocurrió un error inesperado"); throwError }
        this.toastrSrv.success("Empleado actualizado con éxito");
        this.employeeSrv.getEmployees().subscribe(response => {
          if (!response) { throwError; }
          console.info(response);
          this.employees = response;
        });
      })
    }
  }

}
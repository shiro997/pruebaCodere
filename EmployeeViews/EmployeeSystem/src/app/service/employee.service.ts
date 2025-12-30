import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/assets/environment/environment';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService{
  env = environment;
  headers:HttpHeaders = new HttpHeaders({
    'Access-control-Allow-origin':'*',
    'content-type':'application/json'
  })

  constructor(private http:HttpClient){}

  getEmployees():Observable<Employee[]>{
    let url = `${this.env.urlSecurity}/api/v1/Employee`;
    return this.http.get<Employee[]>(url,{headers:this.headers});
  }

  createEmployee(employee:Employee):Observable<Employee>{
    let url = `${this.env.urlSecurity}/api/v1/Employee`;
    let body = JSON.stringify(employee)
    return this.http.post<Employee>(url,body,{headers:this.headers})
  }

  updateEmployee(employee:Employee):Observable<Boolean>{
    let url = `${this.env.urlSecurity}/api/v1/Employee/${employee.codeEmployee}`;
    let body = JSON.stringify(employee)
    return this.http.put<Boolean>(url,body,{headers:this.headers});
  }

  deleteEmployee(codeEmployee:number):Observable<Boolean>{
    let url = `${this.env.urlSecurity}/api/v1/Employee/${codeEmployee}`;
    return this.http.delete<Boolean>(url,{headers:this.headers});
  }
}
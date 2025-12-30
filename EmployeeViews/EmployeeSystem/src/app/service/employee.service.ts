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
}
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/assets/environment/environment';
import { Group } from '../models/group';

@Injectable({
  providedIn: 'root'
})
export class GroupService{
  env = environment;
  headers:HttpHeaders = new HttpHeaders({
    'Access-control-Allow-origin':'*',
    'content-type':'application/json'
  })

  constructor(private http:HttpClient){}

  getGroups():Observable<Group[]>{
    let url = `${this.env.urlSecurity}/api/v1/Group`;
    return this.http.get<Group[]>(url,{headers:this.headers});
  }
}
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeeComponent } from './Employee/employee.component';
import { EmployeeFormComponent } from './Employee/form/employee.form.component';
import { EmployeeService } from './service/employee.service';
import { GroupService } from './service/group.service';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    EmployeeFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [
    EmployeeService,
    GroupService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

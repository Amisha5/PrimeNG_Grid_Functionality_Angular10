import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { PasswordModule } from "primeng/password";
import { DividerModule } from "primeng/divider";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {TableModule} from 'primeng/table';
import { EmployeeRecordService } from './employee-record.service';
import { InputTextModule } from 'primeng/inputtext';
import {ButtonModule} from 'primeng/button';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    PasswordModule,
    DividerModule,
    FormsModule,
    ButtonModule,
    HttpClientModule,
    NgbModule,
    TableModule,
    InputTextModule
  ],
  providers: [EmployeeRecordService],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { Component } from '@angular/core';
import { EmployeeRecordService } from './employee-record.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Angular10PrimeNgGrid';
  value2: string='';
  EmployeeList=[];
  EmployeeTempList=[];
 
  
  constructor(private service:EmployeeRecordService) { }
  ngOnInit():void{
    this.getEmployeeDetails();
   }
  getEmployeeDetails()
  {
    this.service.getEmployeeData().subscribe(data=>
      {
        this.EmployeeList=[];
        this.EmployeeTempList=data;
        
          for (let index = 0; index < this.EmployeeTempList.length; index++) {
            this.EmployeeList.push({
              employeeId:this.EmployeeTempList[index].employeeId,
              employeeName: this.EmployeeTempList[index].employeeName,
              employeeSalary: this.EmployeeTempList[index].employeeSalary,
              employeeContactNumber:this.EmployeeTempList[index].employeeContactNumber
            });
          }
        });
      }
}

export class InputParamDetails{
  
 employeeId:number;
 employeeName:string;
 employeeSalary:number;
 employeeContactNumber:string;

}
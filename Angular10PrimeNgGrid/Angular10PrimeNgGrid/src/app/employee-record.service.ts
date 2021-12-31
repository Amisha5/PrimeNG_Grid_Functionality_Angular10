import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeRecordService {
  readonly APIURL="https://localhost:44325/api/";
  
  constructor(private readonly http: HttpClient) { }

  getEmployeeData():Observable<any[]>
  {
    return this.http.get<any>(this.APIURL+'Employee');
  }
}

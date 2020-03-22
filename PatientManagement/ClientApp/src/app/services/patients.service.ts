import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';

export class State {
  id: number;
  code: string;
  name: string;
}

export class Patient {
  id: number;
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  streetAddress: string;
  suburb: string;
  postCode: number;
  stateId: number;
  email: string;
  phone: string;
  gender: string;
  emergencyContactName: string;
  emergencyContactNumber: string;
  stateCode: string;
  strDob: string;
  createdBy: string;
  createdOn: Date;
  updatedBy: string;
  updatedOn: Date;
 }

@Injectable({
  providedIn: 'root'
})
export class PatientsService {
  routePrefix = 'api/patient';

  constructor(private http: HttpClient) { }

  public getStates(): Observable<Array<State>> {
    const url = this.routePrefix;
    const data = this.http.get<Array<State>>(`${this.routePrefix}/states`)
      .pipe(
        tap(item => {
          return item;
        }),
        catchError(this.handleError<any>('getStates'))
      );
    return data;
  }

  public getPatients(): Observable<Array<Patient>> {
    const data = this.http.get<Array<Patient>>(`${this.routePrefix}`)
      .pipe(
        tap(item => {
          return item;
        }),
        catchError(this.handleError<any>('getPatients'))
      );
    return data;
  }

  public getPatient(id: number): Observable<Patient> {
    const data = this.http.get<Array<Patient>>(`${this.routePrefix}`)
      .pipe(
        tap(item => {
          return item;
        }),
        catchError(this.handleError<any>(`getPatient id=${id}`))
      );
    return data;
  }

  public addPatient(model: Patient): Observable<Patient> {
    const data = this.http.post<Patient>(`${this.routePrefix}`, model)
      .pipe(
        tap(item => {
          return item;
        }),
        catchError(this.handleError<any>(`addPatient`))
      );
    return data;
  }

  public editPatient(id: number, model: Patient): Observable<Patient> {
    const data = this.http.put<Patient>(`${this.routePrefix}/id`, model)
      .pipe(
        tap(item => {
          return item;
        }),
        catchError(this.handleError<any>(`addPatient`))
      );
    return data;
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}

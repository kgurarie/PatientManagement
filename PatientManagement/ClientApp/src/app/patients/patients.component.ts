import { Component, OnInit } from '@angular/core';
import { State, Patient, PatientsService } from '../services/patients.service';

@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html',
  styleUrls: ['./patients.component.css']
})
export class PatientsComponent implements OnInit {
  states: Array<State>;
  patients: Array<Patient>;
  isLoaded: boolean;

  constructor(private patientService: PatientsService) { }

  ngOnInit() {
    this.patientService.getStates().subscribe(data => {
      this.states = data;

      this.patientService.getPatients().subscribe(res => {
        this.patients = res;

        if (this.patients && this.patients.length > 0) {
          for (let i = 0; i < this.patients.length; i++) {
            const patient = this.patients[i];
            const state = this.states.find(x => x.id === patient.stateId);
            if (state) {
              patient.stateCode = state.code;
            }
          }
        }

        this.isLoaded = true;
      });
    });
  }

}

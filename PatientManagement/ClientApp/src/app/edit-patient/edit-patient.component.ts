import { Component, OnInit } from '@angular/core';
import { PatientsService, State, Patient } from '../services/patients.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-patient',
  templateUrl: './edit-patient.component.html',
  styleUrls: ['./edit-patient.component.css']
})
export class EditPatientComponent implements OnInit {
  states: Array<State>;
  patient: Patient;
  id: number;
  isLoaded: boolean;
  patientForm: FormGroup;
  genders = ['Male', 'Female'];
  submitted: boolean;

  constructor(private patientService: PatientsService, private route: ActivatedRoute,
  private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.patientService.getStates().subscribe(data => {
      this.states = data;
      this.route.params.subscribe(param => {
        if (param['id']) {
          // Existing patient
          this.id = parseInt(param['id'], 10);
          this.patientService.getPatient(this.id).subscribe(res => {
            this.patient = res;
            this.initForm();
          });
        } else {
          // New patient
          this.initForm();
        }
 
      });
    });
  }

  initForm() {
    this.patientForm = this.formBuilder.group({
      firstName: new FormControl('', { validators: [Validators.required, Validators.maxLength(100)] }),
      lastName: new FormControl('', { validators: [Validators.required, Validators.maxLength(100)] }),
      strDob: new FormControl('', { validators: [Validators.required] }),
      streetAddress: new FormControl('', { validators: [Validators.required, Validators.maxLength(250)] }),
      suburb: new FormControl('', { validators: [Validators.required, Validators.maxLength(100)] }),
      postCode: new FormControl('', { validators: [Validators.required] }),
      stateId: new FormControl('', { validators: [Validators.required] }),
      email: new FormControl('', { validators: [Validators.required, , Validators.maxLength(50)] }),
      phone: new FormControl('', { validators: [Validators.required, Validators.maxLength(20)] }),
      gender: new FormControl('', { validators: [Validators.required, Validators.maxLength(10)] }),
    });
    if (this.patient) {
      // If editing existing patient set initial values on the form
      this.patientForm.patchValue(this.patient);
    }
    this.isLoaded = true;
  }
     
  submit() {
    this.submitted = true;
    if (this.patientForm.touched && this.patientForm.dirty) {

      if (!this.patient) {
        this.patient = new Patient();
      }
      this.patient.firstName = this.getControlValue('firstName');
      this.patient.lastName = this.getControlValue('lastName');
      this.patient.strDob = this.getControlValue('strDob');
      this.patient.streetAddress = this.getControlValue('streetAddress');
      this.patient.suburb = this.getControlValue('suburb');
      this.patient.postCode = parseInt(this.getControlValue('postCode'), 10);
      this.patient.stateId = parseInt(this.getControlValue('stateId'), 10);
      this.patient.email = this.getControlValue('email');
      this.patient.phone = this.getControlValue('phone');
      this.patient.gender = this.getControlValue('gender');

          
      const dobArray = this.patient.strDob.split('/');
      if (dobArray.length === 3) {
        const year = parseInt(dobArray[2], 10);
        const month = parseInt(dobArray[1], 10);
        const day = parseInt(dobArray[1], 10);
        this.patient.dateOfBirth = new Date(year, month, day);
      }
      // TODO: set patient.createdBy or patient.updatedBy to the current logged in user name
      // after authentication is implemented
      if (!this.patient.createdBy) {
        this.patient.createdBy = 'System';
        this.patient.createdOn = new Date();
      } else {
        this.patient.updatedBy = 'System';
        this.patient.updatedOn = new Date();
      }
      this.patientService.addPatient(this.patient).subscribe(response => {
        if (response) {
          this.router.navigate(['../patients'], { relativeTo: this.route });
        } else {
          console.log('Error adding a new patient');
        }
      });
    }
    
  }

  getControl(name: string) {
    const control = this.patientForm.get(name);
    return control;
  }

  getControlValue(name: string) {
    const control = this.getControl(name);
    return control.value;
  }
}

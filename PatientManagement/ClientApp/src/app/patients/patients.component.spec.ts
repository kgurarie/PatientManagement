import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { PatientsComponent } from './patients.component';
import { State, Patient, PatientsService } from '../services/patients.service';
import { of } from 'rxjs';


describe('PatientsComponent', () => {
  let component: PatientsComponent;
  let fixture: ComponentFixture<PatientsComponent>;
  let fakePatientService;

  const states = [];
  let state = new State();
  state.id = 1;
  state.code = 'VIC';
  state.name = 'Victoria';
  states.push(state);
  
  state = new State();
  state.id = 2;
  state.code = 'NSW';
  state.name = 'New South Wales';
  states.push(state);

  const patients = [];

  const patient = new Patient();
  patient.firstName = 'aaa';
  patient.lastName = 'aaa';
  patient.dateOfBirth = new Date(1973, 12, 3);
  patient.streetAddress = 'aaa';
  patient.suburb = 'aaa';
  patient.postCode = 1234;
  patient.stateId = 1 ;
  patient.email = 'aaa@test.com';
  patient.phone = 'aaa';
  patient.gender = 'Female';
  patients.push(patient);

  
  beforeEach(async(() => {
    fakePatientService = jasmine.createSpyObj('PatientService', ['getStates', 'getPatients']);
    fakePatientService.getStates.and.returnValue(of(states));
    fakePatientService.getPatients.and.returnValue(of(patients));

    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      declarations: [PatientsComponent],
      providers: [
        { provide: PatientsService, useValue: fakePatientService }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PatientsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h1').textContent;
    expect(titleText).toEqual('Manage Patients');
  }));
});

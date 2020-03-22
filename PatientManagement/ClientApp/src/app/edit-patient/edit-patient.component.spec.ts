import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { EditPatientComponent } from './edit-patient.component';
import { of } from 'rxjs';
import { State, PatientsService } from '../services/patients.service';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormControl, Validators } from '@angular/forms';

describe('EditPatientComponent', () => {
  let component: EditPatientComponent;
  let fixture: ComponentFixture<EditPatientComponent>;

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

  beforeEach(async(() => {
    fakePatientService = jasmine.createSpyObj('PatientService', ['getStates']);
    fakePatientService.getStates.and.returnValue(of(states));

    TestBed.configureTestingModule({
      imports: [RouterTestingModule, FormsModule, ReactiveFormsModule],
      declarations: [EditPatientComponent],
      providers: [
        { provide: PatientsService, useValue: fakePatientService },
        ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPatientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h1').textContent;
    expect(titleText).toEqual('Add Patient');
  }));
});

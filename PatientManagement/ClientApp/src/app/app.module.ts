import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PatientsComponent } from './patients/patients.component';
import { EditPatientComponent } from './edit-patient/edit-patient.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PatientsComponent,
    EditPatientComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'patients', component: PatientsComponent },
      { path: 'edit-patient', component: EditPatientComponent },
      { path: 'edit-patient/:id', component: EditPatientComponent },

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

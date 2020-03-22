Patient Management 

This application allows users to list and add patients.
Please follow instructions on the home page how to access the Patient List ( click 'Manage Patients' menu option).

Initially the patient list will be empty, but patients can be added.
I have not added proper user entry validation, so please enter Date of Birth in the suggested format (dd/mm/yyyy) and postcode as an integer.


It is built with .NET Core and Angular 8. Data is stored in SQLExpress database ((localdb)\mssqllocaldb). 
EFCore code first is used for database updates.

I initially added Data and Services as separate projects, but to simplify database migrations and reduce time spent
I added them to Web project (this approach is sometimes used when implementing Microservices architechture). 

I added some tests to both back end and front end, but not all possible tests because there was not enough time.
- ServicesTest project - I added a test to check if a patient is actually added to the database. It is more 
  integration test than unit test.
- Angular unit tests - added for the implemented components and the service. 
  To run them: 
     cd PatientManagement\PatientManagement\ClientApp	
     ng test

I tried to run the application on the computer where Angular was not installed, but it was not running straight away.
The following steps should fix it:
To install Angular:
- Download and install Node.js
- Install Angular CLI globally
  npm install -g @angular/cli@8.3.4
- Add to path (it should already be added in the previous step)
C:\Users\Your user\AppData\Roaming\npm
C:\Users\Your user\AppData\Roaming\npm\node_modules\@angular\cli\bin	
- If it is still not running, run the following in PatientManagement\PatientManagement\ClientApp
   npm run start  
   After it is built, stop it and restart the application in Visual Studio


What I would like to add to the application:
- Complete Edit Patient functionality (I wrote some come code, but did not complete it).
- Paging and sorting of the patients
- Add Patient Admissions to the list of patients
- Implement validation for the user entries
- Exception handling
- Authentication
- More unit tests, add end to end tests


 
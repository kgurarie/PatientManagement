Patient Management 

This application allows users to list and add patients.
It is built with .NET Core and Angular 8. Data is stored in SQLExpress database ((localdb)\mssqllocaldb). 
EFCore code first is used for database updates.

I initially added Data and Services as a separate projects, but to simplify database migrations and reduce time spent
I added them to Web project (this approach is often used when implementing Microservices architechture). 

I added some tests to both back end and front end, but not all possible tests because there was not enough time.
- ServicesTest project - I added a test to check if a patient is actually added to the database. It is more 
  integration test than unit test.
- Angular unit tests - added for the implemented components and the service.

I intended to do more, but was not able to complete everything. 

What I would like to add to the application:
- Complete Edit Patient functionality (I wrote some come code, but did not complete it).
- Paging and sorting of the listed patients
- Add Patient Admissions to the list of patients
- Implement validation for the user entries
- Exception handling
- Authentication
- More unit tests, end to end test
 
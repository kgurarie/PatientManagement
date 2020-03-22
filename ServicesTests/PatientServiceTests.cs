using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace ServicesTests
{
    [TestClass()]
    public class PatientServiceTests
    {
        private PatientDbContext _dbContext;
        private IPatientService _patientService;

        public void InitContext()
        {
            var dbContextOptionsBuilder = TestConfigHelper.GetDbContextOptionsBuilder();
    
            _dbContext = new PatientDbContext(dbContextOptionsBuilder.Options);
            _patientService = new PatientService(_dbContext);
        }

        [TestInitialize()]
        public void MyTestInitialize() 
        {
            InitContext();
        }

        [TestMethod()]
        public async Task GetStatesTest()
        {
            var states = await _patientService.GetStates();
            Assert.IsTrue(states.Count == 8);

 
        }

        [TestMethod()]
        public async Task AddPatientTest()
        {
            var patient = new Patient
            {
                FirstName = "Dog",
                LastName = "Diggy",
                DateOfBirth = new DateTime(1960, 4, 12),
                StreetAddress = "66 Cotton St",
                Suburb = "aaaaa",
                PostCode = 1234,
                StateId = 4,
                Email = "diggy@test.com",
                Phone = "11111",
                Gender = "Male",
                EmergencyContactName = "tttt",
                EmergencyContactPhone = "22222",
                CreatedOn = DateTime.UtcNow,
                CreatedBy = "Test"
            };
            var result = await _patientService.AddPatient(patient);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.FirstName, patient.FirstName);

            // Cleanup, delete created user
            await _patientService.DeletePatient(patient.Id);
        }

       


    }
}
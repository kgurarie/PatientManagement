using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class PatientService : IPatientService
    {
        //public PatientRepository(PatientContext dbcontext)
        private PatientDbContext _dbContext;
        public PatientService(PatientDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IList<State>> GetStates()
        {
            var states = await _dbContext.States.OrderBy(x => x.Name).ToListAsync();
            return states;
        }

        public async Task<IList<Patient>> GetPatients()
        {
            var patients = await _dbContext.Patients.Include(x => x.State).Include(x => x.PatientAdmissions)
                .OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToListAsync();
            return patients;

        }
        public async Task<Patient> GetPatient(int id)
        {
            var patient = await _dbContext.Patients.Include(x => x.State).Include(x => x.PatientAdmissions).FirstOrDefaultAsync(x => x.Id == id);
            return patient;
        }
        public async Task<Patient> AddPatient(Patient model)
        {
            if (model == null)
            {
                throw new Exception("model should not be null");
            }
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(x => x.FirstName == model.FirstName &&
                        x.LastName == model.LastName && x.DateOfBirth == model.DateOfBirth);
            if (patient != null)
            {
                throw new Exception("This patient already exists in the database");
            }
            
            await _dbContext.Patients.AddAsync(model);
            await _dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<Patient> EditPatient(int id, Patient model)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePatient(int id)
        {
            var patient = await GetPatient(id);
            _dbContext.Patients.Remove(patient);
            await _dbContext.SaveChangesAsync();
        }

    }
}

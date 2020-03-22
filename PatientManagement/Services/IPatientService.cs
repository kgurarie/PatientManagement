using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPatientService
    {
        Task<IList<State>> GetStates();
        Task<IList<Patient>> GetPatients();
        Task<Patient> GetPatient(int id);
        Task<Patient> AddPatient(Patient patient);
        Task<Patient> EditPatient(int id, Patient patient);
        Task DeletePatient(int id);
    }
}

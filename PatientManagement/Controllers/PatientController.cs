using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;

namespace PatientManagement.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientService _patientService;

        public PatientController(ILogger<PatientController> logger, IPatientService patientService )
        {
            _logger = logger;
            _patientService = patientService;
        }

        /// <summary>
        /// Get all patients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IList<Patient>> GetPatients()
        {
            var result = await _patientService.GetPatients();
            return result;
        }

        /// <summary>
        /// Get patient by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<Patient> GetPatient(int id)
        {
            var result = await _patientService.GetPatient(id);
            return result;
        }

        /// <summary>
        /// Add a new patient
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Patient> AddPatient(Patient model)
        {
            var result = await _patientService.AddPatient(model);
            return result;
        }

        /// <summary>
        /// Edit patient
        /// </summary>
        /// <param name="id"></param>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        public async Task<Patient> EditPatient(int id, [FromBody] Patient model)
        {
            var result = await _patientService.EditPatient(id, model);
            return result;
        }

        [HttpGet]
        [Route("states")]
        public async Task<IList<State>> GetStates()
        {
            var result = await _patientService.GetStates();
            return result;
        }
    }

  
}
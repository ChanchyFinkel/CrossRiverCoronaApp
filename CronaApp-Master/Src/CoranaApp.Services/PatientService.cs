using AutoMapper;
using CoronaApp.Dal;
using CoronaApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PatientService : IPatientService
    {
        IPatientRepository _PatientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository PatientRepository, IMapper mapper)
        {
            _PatientRepository = PatientRepository;
            _mapper = mapper;
        }
        public async Task<string> addNewPatient(Patient newPatient)
        {
           // Patient patient = _mapper.Map<Patient>(newPatient);
            return await _PatientRepository.addNewPatient(newPatient);
        }

        public async Task<Patient> getPatientById(string id)
        {
            return await _PatientRepository.getPatientById(id);
        }
    }
}

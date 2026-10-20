using Data_Hospital_Manager;
using Data_Hospital_Manager.Entities;
using Data_Hospital_Manager.Migrations;
using Hospital_Manager_Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Manager_Core.Services
{
    public class PatientService : IPatientService
    {
        private readonly HospitalDbContext context;
        public PatientService(HospitalDbContext context)
        {
            this.context = context;
        }
        public async Task AddPatientAsync(Patient patient)
        {
            context.Patients.Add(patient);
            await context.SaveChangesAsync();
        }

        public async Task DeletePatientAsync(int id)
        {
            Patient? p = await context.Patients
                .Include(p => p.DoctorPatients)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (p != null)
            {
                context.DoctorsPatients.RemoveRange(p.DoctorPatients);
                context.Patients.Remove(p);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Patient>> GetAllPetientsAsync()
        {
            return await context.Patients
                .Include(p => p.DoctorPatients)
                .ThenInclude(dp => dp.Doctor)
                .ToListAsync();
        }

        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            return await context.Patients.FindAsync(id);
        }

        public async Task<Patient?> GetPatientWithDoctorsAsync(int id)
        {
            return await context.Patients
                .Include(p => p.DoctorPatients)
                .ThenInclude(dp => dp.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdatePatientAsync(Patient patient, List<int> doctorIds)
        {
            patient.DoctorPatients.Clear();
            foreach (var dId in doctorIds.Distinct())
            {
                patient.DoctorPatients.Add(new DoctorPatient
                {
                    DoctorId = dId,
                    PatientId = patient.Id
                });
            }

            await context.SaveChangesAsync();
        }
    }
}

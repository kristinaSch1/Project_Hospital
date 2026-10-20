using Data_Hospital_Manager;
using Data_Hospital_Manager.Entities;
using Hospital_Manager_Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Manager_Core.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HospitalDbContext context;
        public DoctorService(HospitalDbContext context)
        {
            this.context = context;
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            context.Doctors.Add(doctor);
            await context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            Doctor? d = context.Doctors
                .Include(d => d.DoctorPatients)
                .FirstOrDefault(x => x.Id == id);
            if(d != null)
            {
                context.DoctorsPatients.RemoveRange(d.DoctorPatients);
                context.Doctors.Remove(d);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            return await context.Doctors.FindAsync(id);
        }

        public async Task<Doctor?> GetDoctorDetailsAsync(int id)
        {
            return await context.Doctors
                .Include(d => d.Hospital)
                .Include(d => d.DoctorPatients)
                    .ThenInclude(dp => dp.Patient)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await context.Doctors
                .Include(d => d.Hospital)
                .ToListAsync();
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            await context.SaveChangesAsync();
        }
    }

}

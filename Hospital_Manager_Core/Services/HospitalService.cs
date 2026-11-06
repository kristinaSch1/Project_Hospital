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
    public class HospitalService : IHospitalService
    {
        private readonly HospitalDbContext context;
        public HospitalService(HospitalDbContext context)
        {
            this.context = context;
        }
        public async Task AddHospitalAsync(Hospital hospital)
        {
            context.Hospitals.Add(hospital);
            await context.SaveChangesAsync();  
        }
        public async Task DeleteHospitalAsync(int id)
        {
            Hospital h = await context.Hospitals.FirstAsync(h => h.Id == id);

            if(h != null)
            {
                h.IsDeleted = true;
                await context.SaveChangesAsync();
            }
        }
        public async Task<Hospital?> GetHospitalByIdAsync(int id)
        {
            return await context.Hospitals.FindAsync(id);
        }
        public async Task UpdateHospitalAsync(Hospital hospital)
        {
            await context.SaveChangesAsync();
        }

        public async Task<List<Hospital>> GetAllHospitalsAsync(string? search = null, int? minBeds = null, string? sortOrder = null)
        {
            var query = context.Hospitals.Where(h => !h.IsDeleted);

            if(!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(h => h.Name.Contains(search));
            }

            if(minBeds.HasValue)
            {
                query = query.Where(h => h.BedsCount >= minBeds.Value);
            }

            if(sortOrder == "name")
            {
                query = query.OrderBy(h => h.Name);
            }
            else if(sortOrder == "beds_asc")
            {
                query = query.OrderBy(h => h.BedsCount);
            }
            else if(sortOrder == "beds_desc")
            {
                query = query.OrderByDescending(h => h.BedsCount);
            }
            else
            {
                query = query.OrderBy(h => h.Name);
            }

            return await query.ToListAsync();
        }
    }
}

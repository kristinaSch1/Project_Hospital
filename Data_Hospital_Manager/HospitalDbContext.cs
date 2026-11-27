using Data_Hospital_Manager.Configuration;
using Data_Hospital_Manager.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Hospital_Manager
{
    public class HospitalDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
            : base(options)
        {
        }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<DoctorPatient> DoctorPatients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<DoctorPatient>()
            //    .HasKey(dp => new { dp.DoctorId, dp.PatientId });

            //modelBuilder.Entity<DoctorPatient>()
            //    .HasOne(dp => dp.Doctor)
            //    .WithMany(d => d.Patients)
            //    .HasForeignKey(dp => dp.DoctorId)
            //    .OnDelete(DeleteBehavior.Cascade);//za da se iztriqt zapisite v i dvete tablici

            //modelBuilder.Entity<DoctorPatient>()
            //    .HasOne(dp => dp.Patient)
            //    .WithMany(p => p.Doctors)
            //    .HasForeignKey(dp => dp.PatientId)
            //    .OnDelete(DeleteBehavior.Cascade);



            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new HospitalConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new PatientConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorPatientConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}

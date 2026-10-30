using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Hospital_Manager.Configuration
{
    public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
    {
        public void Configure(EntityTypeBuilder<Hospital> builder)
        {
            builder.HasData
                (
                    new Hospital
                    {
                        Id = 1,
                        Name = "МБАЛ Казанлък",
                        Address = "Казанлък",
                        Email = "mbalkazanlak@mail.bg",
                        PhoneNumber = "0899823296",
                        BedsCount = 200,
                        IsDeleted = false,
                        CreatedOn = DateTime.Now,
                    },
                    new Hospital
                    {
                        Id = 2,
                        Name = "МБАЛ Стара Загора",
                        Address = "Стара Загора",
                        Email = "mbalstz@mail.bg",
                        PhoneNumber = "0899823294",
                        BedsCount = 150,
                        IsDeleted = false,
                        CreatedOn = DateTime.Now,
                    }
                );
        }
    }
}

using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Code).IsRequired();
            builder.Property(d => d.Name).IsRequired()
                                         .HasMaxLength(100)
                                         .HasColumnType("nvarchar");
            builder.Property(d => d.Location).HasMaxLength(100)
                                             .HasColumnType("nvarchar");
        }
    }
}

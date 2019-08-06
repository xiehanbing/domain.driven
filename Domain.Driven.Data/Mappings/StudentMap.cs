using Domain.Driven.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Driven.Data.Mappings
{
    /// <summary>
    /// 学生map
    /// </summary>
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(x => x.UserNo);
            builder.Property(c=>c.UserNo).HasColumnName("UserNo").IsRequired();
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)").HasMaxLength(50).IsRequired();
        }
    }
}
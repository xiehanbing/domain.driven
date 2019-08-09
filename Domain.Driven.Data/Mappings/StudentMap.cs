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
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(11)
                .IsRequired();
            builder.Property(c => c.Phone)
                .HasColumnType("varchar(100)")
                .HasMaxLength(20)
                .IsRequired();
            //处理值对象配置 否则会被视为实体
            builder.OwnsOne(p => p.Address, sa =>
            {
                sa.Property(x => x.Province).HasColumnType("varchar(50)");
                sa.Property(x => x.City).HasColumnType("varchar(50)");
                sa.Property(x => x.County).HasColumnType("varchar(100)");
            }); //可以对值对象进行数据库重命名，还有其他的一些操作，请参考官网


        }
    }
}
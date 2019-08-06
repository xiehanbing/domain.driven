using System.IO;
using Domain.Driven.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Domain.Driven.Data.Context
{
    /// <summary>
    /// 定义 核心子领域-学习上下文
    /// </summary>
    public class StudyContext:DbContext
    {
        /// <summary>
        /// 学生 dbset
        /// </summary>
        public DbSet<Student> Students { get; set; }
        /// <summary>
        /// 重写自定义map 配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMap());
            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// 重写链接数据库
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // <== compile failing here
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
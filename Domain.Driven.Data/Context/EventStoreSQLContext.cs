using System.IO;
using Domain.Driven.Core.Events;
using Domain.Driven.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Domain.Driven.Data.Context
{
    /// <summary>
    /// 事件存储数据库上下文 继承DbContext
    /// </summary>
    public class EventStoreSqlContext:DbContext
    {
        /// <summary>
        /// 事件存储模型
        /// </summary>
        public DbSet<StoredEvent> StoredEvent { get; set; }
        /// <summary>
        /// 重写自定义map 配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());
            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// 重写链接数据库
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //从 json 中读取 配置信息
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // <== compile failing here
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString(ConfigConnectionConstContext.DefaultConnection));
            //定义要使用的数据库
            //正确的是这样，直接连接字符串即可  optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            //我是读取的文件内容，为了数据安全
            //optionsBuilder.UseSqlServer(File.ReadAllText(config.GetConnectionString(ConfigConnectionConstContext.DefaultConnection)));
        }
    }
}
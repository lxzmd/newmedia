using LogisticsExpress.Model;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsExpress.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BaseDBContext : DbContext
    {
        public BaseDBContext() : base("LogisticsExpressCon")
        {
           
        }


        public virtual IDbSet<TopicQuestion> TopicQuestions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //移除表名为复数
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //自动添加实现EntityTypeConfiguration的类
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}

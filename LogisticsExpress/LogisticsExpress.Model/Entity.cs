using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsExpress.Model
{
    public class Entity<TPrimaryKey>: IEntity<TPrimaryKey>
    {

        public virtual long? CreatorUserId { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual string CreatorUserName { get; set; }

        public virtual TPrimaryKey Id { get; set; }

        protected Entity()
        {
            CreationTime = DateTime.Now;
        }
    }
}

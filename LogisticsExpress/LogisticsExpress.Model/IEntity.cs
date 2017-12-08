using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsExpress.Model
{
    public interface IEntity<TPrimaryKey>
    {
       TPrimaryKey Id { get; set; }
    }
}

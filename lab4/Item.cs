using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class Item : IExpired
    {
        public string Name { get; set; }
        public DateTime DateTime_ { get; set; }
        public Item(string name, DateTime dateTime_)
        {
            Name = name;
            DateTime_ = dateTime_;
        }
        public int GetExpireDays()
        {
            return (DateTime_.Date - DateTime.Now.Date).Days;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplexCoreFive.Models
{
    public class Country
    {
        public Country()
        {
            CreateDate = DateTime.Now;
        }

        [Key]
        public long Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

    }
}

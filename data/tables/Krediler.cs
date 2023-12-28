using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace data.tables
{
    public class Krediler
    {
        [Key]
        public int id {get;set;}
        public double ay {get;set;}
        public double tl {get;set;}
        public double oran {get;set;}
        public string name {get;set;}
    }
}
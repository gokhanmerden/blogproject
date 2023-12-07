using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace data.tables
{
    public class Blog
    {
        public Blog() {
            Posts = new List<Post>();
        }
        [Key]
        public int id { get; set; }
        public string Url { get; set; }
        private int Rating { get; set; }
        public List<Post> Posts { get; set; }
    }
}
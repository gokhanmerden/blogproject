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
        private int _id;
        [Key]
        public int id { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
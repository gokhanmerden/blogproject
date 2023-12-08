using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace data.uows
{
    public class BlogUnitOfWork
    {
        private BlogContext _context;

        public BlogUnitOfWork() {
            _context = new BlogContext();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data
namespace data.uows
{
    public class BlogUnitOfWork
    {
        private _context : BlogContext;

        public BlogUnitOfWork() {
            _context = new BlogContext();
        }
    }
}
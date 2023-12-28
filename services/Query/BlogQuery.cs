using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.tables;
using MediatR;
using data.uows;
using Microsoft.EntityFrameworkCore;

namespace services.Query
{
    public class BlogQuery: IRequest<Blog>
    {
        public int id {get;set;}

        public class Handler : IRequestHandler<BlogQuery,Blog>
        {
            async Task<Blog> IRequestHandler<BlogQuery, Blog>.Handle(BlogQuery request, CancellationToken cancellationToken)
            {
                var uow = new BlogUnitOfWork();
                var blog = await uow.blogRepository.GetQuery()
                .Include(i=> i.Posts)
                .Where(w=> w.id == request.id).FirstOrDefaultAsync();
                return blog;
            }
        }
    }
}
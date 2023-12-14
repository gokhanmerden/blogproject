using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using services.Query;

namespace webapi.Blog
{
    public class BlogMap
    {
        public static void AddMap(WebApplication app) {
            app.MapGet("blog/{id}", (int id,IMediator mediator) => {
                return mediator.Send(new BlogQuery() { id = id});
            });
        }
    }
}
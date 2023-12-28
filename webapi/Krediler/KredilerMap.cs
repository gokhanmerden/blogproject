using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using services.Query;

namespace webapi.Blog
{
    public class KredilerMap
    {
        public static void AddMap(WebApplication app) {
            app.MapGet("krediler", (IMediator mediator) => {
                return mediator.Send(new KredilerQuery());
            });
        }
    }
}
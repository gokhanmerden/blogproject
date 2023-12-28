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
    public class KredilerQuery: IRequest<List<Krediler>>
    {
        //public int id {get;set;}

        public class Handler : IRequestHandler<KredilerQuery,List<Krediler>>
        {
            public async Task<List<Krediler>> Handle(KredilerQuery request, CancellationToken cancellationToken)
            {
                var uow = new BlogUnitOfWork();
                var krediler = await uow.kredilerRepository.GetQuery()
                .ToListAsync();
                return krediler;
            }
        }
    }
}
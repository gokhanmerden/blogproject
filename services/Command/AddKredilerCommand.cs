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
    public class AddKredilerCommand: IRequest<Krediler>
    {
        public Krediler kredi {get;set;}

        public class Handler : IRequestHandler<AddKredilerCommand,Krediler>
        {
            public async Task<Krediler> Handle(AddKredilerCommand request, CancellationToken cancellationToken)
            {
                return await Task.Factory.StartNew( () => {
                    var uow = new BlogUnitOfWork();
                    var krediler = uow.kredilerRepository.Add(request.kredi);
                    uow.kredilerRepository.Save();
                    return krediler;
                });
               
            }

            
        }
    }
}
using MediatR;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ClientToDoList.Queries
{
    public class GetAllClientQuery : IRequest<List<Client>>
    {
        public GetAllClientQuery() { }
    }
}

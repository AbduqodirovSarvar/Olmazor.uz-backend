using MediatR;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.MessageToDoList.Queries
{
    public class GetAllMessageQuery : IRequest<List<Message>>
    {
        public GetAllMessageQuery() { }
    }
}

using MediatR;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ContactToDoList.Queries
{
    public class GetAllContactQuery : IRequest<List<Contact>>
    {
        public GetAllContactQuery() { }
    }
}

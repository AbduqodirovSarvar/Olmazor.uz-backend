using MediatR;
using OlmaTech.Domain.Entities;
using OlmaTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ContactToDoList.Commands
{
    public class CreateContactCommand : IRequest<Contact>
    {
        public Communication Name { get; set; }
        public string Link { get; set; } = null!;
    }
}

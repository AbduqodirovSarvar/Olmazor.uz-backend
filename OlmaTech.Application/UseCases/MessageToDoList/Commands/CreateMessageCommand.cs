using MediatR;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.MessageToDoList.Commands
{
    public class CreateMessageCommand : IRequest<Message>
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}

using MediatR;
using OlmaTech.Domain.Entities;
using OlmaTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ContactToDoList.Commands
{
    public class UpdateContactCommand : IRequest<Contact>
    {
        [Required]
        public Guid Id { get; set; }
        public Communication? Name { get; set; } = null;
        public string? Link { get; set; } = null;

    }
}

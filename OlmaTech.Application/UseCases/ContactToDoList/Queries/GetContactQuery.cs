using MediatR;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ContactToDoList.Queries
{
    public class GetContactQuery : IRequest<Contact>
    {
        [Required]
        public Guid Id { get; set; }
    }
}

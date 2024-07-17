using MediatR;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.MessageToDoList.Queries
{
    public class GetMessageQuery : IRequest<Message>
    {
        [Required]
        public Guid Id { get; set; }
    }
}

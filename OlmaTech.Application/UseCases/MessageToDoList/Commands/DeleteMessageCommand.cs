using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.MessageToDoList.Commands
{
    public class DeleteMessageCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}

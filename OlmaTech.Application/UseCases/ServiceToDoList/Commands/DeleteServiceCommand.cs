using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ServiceToDoList.Commands
{
    public class DeleteServiceCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}

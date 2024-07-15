using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ClientToDoList.Commands
{
    public class DeleteClientCommand : IRequest<bool>
    {
        [Required]
        public Guid Id { get; set; }
    }
}

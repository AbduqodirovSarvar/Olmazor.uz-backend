using MediatR;
using OlmaTech.Application.Models;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.UserToDoList.Queries
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        [Required]
        public Guid Id { get; set; }
    }
}

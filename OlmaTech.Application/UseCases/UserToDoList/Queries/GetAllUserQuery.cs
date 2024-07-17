using MediatR;
using OlmaTech.Application.Models;
using OlmaTech.Domain.Entities;
using OlmaTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.UserToDoList.Queries
{
    public class GetAllUserQuery : IRequest<List<UserViewModel>>
    {
        public UserRole? Role { get; set; } = null;
        public Gender? Gender { get; set; } = null;

    }
}

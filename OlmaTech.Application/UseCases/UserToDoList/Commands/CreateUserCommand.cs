using MediatR;
using Microsoft.AspNetCore.Http;
using OlmaTech.Domain.Entities;
using OlmaTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.UserToDoList.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Firstname { get; set; } = null!;
        public string FirstnameRu { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string LastnameRu { get; set; } = null!;
        [Phone]
        public string Phone { get; set; } = null!;

        public IFormFile Photo { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public UserRole Userrole { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; } = null!;
    }
}

using MediatR;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Models
{
    public class LoginViewModel
    {
        public User? User { get; set; }
        public string? AccessToken { get; set; }
    }
}

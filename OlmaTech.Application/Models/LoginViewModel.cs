using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Models
{
    public class LoginViewModel
    {
        public UserViewModel? User { get; set; }
        public string? AccessToken { get; set; }
    }
}

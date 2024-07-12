using OlmaTech.Domain.Abstractions;
using OlmaTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Domain.Entities
{
    public class User : PersonBase
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        public UserRole Userrole { get; set; }
        public Gender Gender { get; set; }
        public string PasswordHash { get; set; } = null!;
    }
}

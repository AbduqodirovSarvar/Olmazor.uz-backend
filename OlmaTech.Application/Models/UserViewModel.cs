using OlmaTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public LocalizableViewModel Firstname { get; set; } = null!;
        public LocalizableViewModel Lastname { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Photo { get; set; }
        public string? Email { get; set; }
        public EnumViewModel? Userrole { get; set; }
        public EnumViewModel? Gender { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

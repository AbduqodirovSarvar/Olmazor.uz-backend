using OlmaTech.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Domain.Entities
{
    public class Message : AudiTableEntity
    {
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Text { get; set; } = null!;
        public bool IsSeen { get; set; } = false;
        public bool IsReplied { get; set; } = false;
    }
}

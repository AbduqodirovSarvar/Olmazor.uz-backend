using OlmaTech.Domain.Abstractions;
using OlmaTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Domain.Entities
{
    public class Contact : AudiTableEntity
    {
        public Communication Name { get; set; }
        public string Link { get; set; } = null!;
    }
}

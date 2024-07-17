using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Domain.Abstractions
{
    public class PersonBase : AudiTableEntity
    {
        public string Firstname { get; set; } = null!;
        public string FirstnameRu { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string LastnameRu { get; set; } = null!;
        [Phone]
        public string Phone { get; set; } = string.Empty;

        public string? Photo { get; set; }
    }
}

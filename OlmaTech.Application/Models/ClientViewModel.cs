using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Models
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }
        public LocalizableViewModel Firstname { get; set; } = null!;
        public LocalizableViewModel Lastname { get; set; } = null!;
        [Phone]
        public string Phone { get; set; } = string.Empty;

        public string Photo { get; set; } = null!;
        public LocalizableViewModel Position { get; set; } = null!;
        public LocalizableViewModel Comment { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

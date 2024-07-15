using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Models
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }
        public LocalizableViewModel Position { get; set; } = null!;
        public LocalizableViewModel Comment { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid UpdatedAt { get; set; }
    }
}

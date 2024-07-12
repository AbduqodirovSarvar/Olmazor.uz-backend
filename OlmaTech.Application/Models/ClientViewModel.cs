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
        public string Position { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid UpdatedAt { get; set; }
    }
}

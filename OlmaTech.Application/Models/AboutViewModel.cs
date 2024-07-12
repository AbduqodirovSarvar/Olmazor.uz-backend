using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Models
{
    public class AboutViewModel
    {
        public Guid Id { get; set; }
        public string Address { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string DescriptionFooter { get; set; } = null!;
        public int? Experience { get; set; }
        public string Photo { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid UpdatedAt { get; set; }
    }
}

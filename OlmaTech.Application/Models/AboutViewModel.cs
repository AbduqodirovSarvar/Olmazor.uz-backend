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
        public LocalizableViewModel Address { get; set; } = null!;
        public LocalizableViewModel Title { get; set; } = null!;
        public LocalizableViewModel Description { get; set; } = null!;
        public LocalizableViewModel DescriptionFooter { get; set; } = null!;
        public int? Experience { get; set; }
        public string Photo { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

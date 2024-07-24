using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Models
{
    public class BlogPostViewModel
    {
        public Guid Id { get; set; }
        public LocalizableViewModel Title { get; set; } = null!;
        public LocalizableViewModel Description { get; set; } = null!;
        public string? Link { get; set; } = null;
        public string Photo { get; set; } = null!;
        public DateResponse Date { get; set; } = null!;
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class DateResponse
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}

using OlmaTech.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Domain.Entities
{
    public class Team : PersonBase
    {
        public string PositionUz { get; set; } = null!;
        public string PositionEn { get; set; } = null!;
        public string PositionRu { get; set; } = null!;
        public string PositionUzRu { get; set; } = null!;

        public string? Telegram { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Email { get; set; }
    }
}

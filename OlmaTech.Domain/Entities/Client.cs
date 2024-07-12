using OlmaTech.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Domain.Entities
{
    public class Client : PersonBase
    {
        public string PositionUz { get; set; } = null!;
        public string PositionEn { get; set; } = null!;
        public string PositionRu { get; set; } = null!;
        public string PositionUzRu { get; set; } = null!;

        public string CommentUz { get; set; } = null!;
        public string CommentEn { get; set; } = null!;
        public string CommentRu { get; set; } = null!;
        public string CommentUzRu { get; set; } = null!;
    }
}

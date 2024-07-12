using OlmaTech.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Domain.Entities
{
    public class Service : AudiTableEntity
    {
        // Name 
        public string NameUz { get; set; } = null!;
        public string NameEn { get; set; } = null!;
        public string NameRu { get; set; } = null!;
        public string NameUzRu { get; set; } = null!;

        // Description
        public string DescriptionUz { get; set; } = null!;
        public string DescriptionEn { get; set; } = null!;
        public string DescriptionRu { get; set; } = null!;
        public string DescriptionUzRu { get; set; } = null!;
    }
}

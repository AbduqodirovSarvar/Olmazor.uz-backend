using OlmaTech.Domain.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Domain.Abstractions
{
    public class LocalizableEntity : AudiTableEntity, ILocalizableEntity
    {
        public string NameUz { get; set; } = string.Empty;
        public string NameEn { get; set; } = string.Empty;
        public string NameRu { get; set; } = string.Empty;
        public string NameUzRu { get; set; } = string.Empty;
    }
}

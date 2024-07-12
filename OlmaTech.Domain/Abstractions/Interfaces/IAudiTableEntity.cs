using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Domain.Abstractions.Interfaces
{
    public interface IAudiTableEntity
    {
        Guid CreatedBy { get; set; }
        DateTime CreatedAt { get; set; }
        Guid UpdatedBy { get; set; }
        Guid UpdatedAt { get; set; }
    }
}

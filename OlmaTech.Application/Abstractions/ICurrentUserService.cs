using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Abstractions
{
    public interface ICurrentUserService
    {
        Guid Id { get; set; }
    }
}

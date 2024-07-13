using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Abstractions
{
    public interface IEnumTranslator
    {
        string Translate(Enum value, CultureInfo cultureInfo);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Abstractions
{
    public interface IEmailService
    {
        string GetHash(string password);
        bool VerifyHash(string password, string paswordHash);
    }
}

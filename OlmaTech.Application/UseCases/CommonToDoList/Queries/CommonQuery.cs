using MediatR;
using OlmaTech.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.CommonToDoList.Queries
{
    public class CommonQuery : IRequest<CommonViewModel>
    {
        public CommonQuery() { }
    }
}

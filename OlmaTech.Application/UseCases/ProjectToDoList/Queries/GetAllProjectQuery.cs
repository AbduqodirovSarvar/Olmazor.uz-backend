using MediatR;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ProjectToDoList.Queries
{
    public class GetAllProjectQuery : IRequest<List<Project>>
    {
        public GetAllProjectQuery() { }
    }
}

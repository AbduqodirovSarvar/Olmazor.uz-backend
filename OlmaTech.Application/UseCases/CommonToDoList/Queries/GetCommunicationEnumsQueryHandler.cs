using AutoMapper;
using MediatR;
using OlmaTech.Application.Models;
using OlmaTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.CommonToDoList.Queries
{
    public class GetCommunicationEnumsQueryHandler(
        IMapper mapper
        ) : IRequestHandler<GetCommunicationEnumsQuery, List<EnumViewModel>>
    {
        private readonly IMapper _mapper = mapper;

        public Task<List<EnumViewModel>> Handle(GetCommunicationEnumsQuery request, CancellationToken cancellationToken)
        {
            var communicationEnums = Enum.GetValues(typeof(Communication)).Cast<Communication>();

            return Task.FromResult(_mapper.Map<List<EnumViewModel>>(communicationEnums));
        }
    }
}

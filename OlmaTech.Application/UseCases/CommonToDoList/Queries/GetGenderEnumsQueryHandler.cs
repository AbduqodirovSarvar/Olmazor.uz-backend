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
    public class GetGenderEnumsQueryHandler(
        IMapper mapper
        ) : IRequestHandler<GetGenderEnumsQuery, List<EnumViewModel>>
    {
        private readonly IMapper _mapper = mapper;
        public Task<List<EnumViewModel>> Handle(GetGenderEnumsQuery request, CancellationToken cancellationToken)
        {
            var genderEnums = Enum.GetValues(typeof(Gender)).Cast<Gender>();
            return Task.FromResult(_mapper.Map<List<EnumViewModel>>(genderEnums));
        }
    }
}

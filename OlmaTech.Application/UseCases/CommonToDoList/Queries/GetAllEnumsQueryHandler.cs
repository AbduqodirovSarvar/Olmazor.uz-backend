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
    public class GetAllEnumsQueryHandler(
        IMapper mapper
        ) : IRequestHandler<GetAllEnumsQuery, List<EnumViewModel>>
    {
        private readonly IMapper _mapper = mapper;

        public Task<List<EnumViewModel>> Handle(GetAllEnumsQuery request, CancellationToken cancellationToken)
        {
            var genderEnums = Enum.GetValues(typeof(Gender)).Cast<Gender>();
            var userRoleEnums = Enum.GetValues(typeof(UserRole)).Cast<UserRole>();
            var communicationEnums = Enum.GetValues(typeof(Communication)).Cast<Communication>();

            var enumViewModels = new List<EnumViewModel>();

            enumViewModels.AddRange(genderEnums.Select(g => _mapper.Map<EnumViewModel>(g)));
            enumViewModels.AddRange(userRoleEnums.Select(ur => _mapper.Map<EnumViewModel>(ur)));
            enumViewModels.AddRange(communicationEnums.Select(c => _mapper.Map<EnumViewModel>(c)));

            return Task.FromResult(enumViewModels);
        }
    }
}

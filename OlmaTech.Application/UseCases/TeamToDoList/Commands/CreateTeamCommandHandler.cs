using AutoMapper;
using MediatR;
using OlmaTech.Application.Abstractions;
using OlmaTech.Application.Services;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.TeamToDoList.Commands
{
    public class CreateTeamCommandHandler(
        IAppDbContext appDbContext,
        IMapper mapper,
        IFileService fileService
        ) : IRequestHandler<CreateTeamCommand, Team>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IMapper _mapper = mapper;
        private readonly IFileService _fileService = fileService;

        public async Task<Team> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var photoFileName = await _fileService.SaveFileAsync(request.Photo)
                                ?? throw new Exception("Cannot save the photo");

            var team = _mapper.Map<Team>(request);
            team.Photo = photoFileName;

            await _appDbContext.Teams.AddAsync(team, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return team;
        }
    }
}

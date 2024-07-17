using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class UpdateTeamCommandHandler(
        IAppDbContext appDbContext,
        IFileService fileService
        ) : IRequestHandler<UpdateTeamCommand, Team>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IFileService _fileService = fileService;

        public async Task<Team> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _appDbContext.Teams.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                          ?? throw new Exception("Team not found");

            if(request.Photo != null)
            {
                var newPhotoName = await _fileService.SaveFileAsync(request.Photo) 
                                                    ?? throw new Exception("Cannot save the photo");
                team.Photo = newPhotoName;
            }

            team.Firstname = request.Firstname ?? team.Firstname;
            team.FirstnameRu = request.FirstnameRu ?? team.FirstnameRu;
            team.Lastname = request.Lastname ?? team.Lastname;
            team.LastnameRu = request.LastnameRu ?? team.LastnameRu;
            team.Phone = request.Phone ?? team.Phone;
            team.PositionEn = request.PositionEn ?? team.PositionEn;
            team.PositionRu = request.PositionRu ?? team.PositionRu;
            team.PositionUz = request.PositionUz ?? team.PositionUz;
            team.PositionUzRu = request.PositionUzRu ?? team.PositionUzRu;
            team.Telegram = request.Telegram ?? team.Telegram;
            team.Instagram = request.Instagram ?? team.Instagram;
            team.Twitter = request.Twitter ?? team.Twitter;
            team.Email = request.Email ?? team.Email;

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return team;
        }
    }
}

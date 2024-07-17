using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ClientToDoList.Commands
{
    public class UpdateClientCommandHandler(
        IAppDbContext appDbContext,
        IFileService fileService
        ) : IRequestHandler<UpdateClientCommand, Client>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IFileService _fileService = fileService;

        public async Task<Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _appDbContext.Clients.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                            ?? throw new Exception("Clinet not found");

            if (request.Photo != null)
            {
                var newPhotoName = await _fileService.SaveFileAsync(request.Photo) 
                                                ?? throw new Exception("Cannot save the photo");
                client.Photo = newPhotoName;
            }

            client.Firstname = request.Firstname ?? client.Firstname;
            client.Lastname = request.Lastname ?? client.Lastname;
            client.Phone = request.Phone ?? client.Phone;
            client.PositionEn = request.PositionEn ?? client.PositionEn;
            client.PositionRu = request.PositionRu ?? client.PositionRu;
            client.PositionUz = request.PositionUz ?? client.PositionUz;
            client.PositionUzRu = request.PositionUzRu ?? client.PositionUzRu;
            client.CommentEn = request.CommentEn ?? client.CommentEn;
            client.CommentRu = request.CommentRu ?? client.CommentRu;
            client.CommentUz = request.CommentUz ?? client.CommentUz;
            client.CommentUzRu = request.CommentUzRu ?? client.CommentUzRu;

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return client;
        }
    }
}

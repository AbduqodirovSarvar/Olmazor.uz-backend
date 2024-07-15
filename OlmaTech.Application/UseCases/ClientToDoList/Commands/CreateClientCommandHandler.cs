using AutoMapper;
using MediatR;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.ClientToDoList.Commands
{
    public class CreateClientCommandHandler(
        IAppDbContext appDbContext,
        IMapper mapper,
        IFileService fileService
        ) : IRequestHandler<CreateClientCommand, Client>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IMapper _mapper = mapper;
        private readonly IFileService _fileService = fileService;

        public async Task<Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var photoFileName = await _fileService.SaveFileAsync(request.Photo)
                                ?? throw new Exception("Cannot save the photo");

            var client = _mapper.Map<Client>(request);
            client.Photo = photoFileName;

            await _appDbContext.Clients.AddAsync(client, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return client;
        }
    }
}

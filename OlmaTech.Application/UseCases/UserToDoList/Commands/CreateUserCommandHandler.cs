using AutoMapper;
using MediatR;
using OlmaTech.Application.Abstractions;
using OlmaTech.Application.Models;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.UserToDoList.Commands
{
    public class CreateUserCommandHandler(
        IAppDbContext appDbContext,
        IFileService fileService,
        IMapper mapper,
        IHashService hashService
        ) : IRequestHandler<CreateUserCommand, UserViewModel>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IFileService _fileService = fileService;
        private readonly IMapper _mapper = mapper;
        private readonly IHashService _hashService = hashService;

        public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var photoFileName = await _fileService.SaveFileAsync(request.Photo) 
                                                ?? throw new Exception("Cannot save the photo");

            user.Photo = photoFileName;
            user.PasswordHash = _hashService.GetHash(request.Password);

            await _appDbContext.Users.AddAsync(user, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserViewModel>(user);
        }
    }
}

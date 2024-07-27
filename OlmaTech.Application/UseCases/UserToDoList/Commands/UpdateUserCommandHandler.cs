using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Application.Models;
using OlmaTech.Domain.Entities;
using OlmaTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.UserToDoList.Commands
{
    public class UpdateUserCommandHandler(
        IAppDbContext appDbContext,
        IFileService fileService,
        IHashService hashService,
        ICurrentUserService currentUserService
        ) : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IFileService _fileService = fileService;
        private readonly IHashService _hashService = hashService;
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.Id, cancellationToken)
                                                 ?? throw new Exception("Current User not found");

            var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                          ?? throw new Exception("User not found");

            if((currentUser.Userrole == UserRole.SuperAdmin || currentUser.Userrole == UserRole.Admin) && currentUser.Id != user.Id && request.Password != null)
            {
                user.PasswordHash = _hashService.GetHash(request.Password);
            }

            if(currentUser.Id == user.Id && !(currentUser.Userrole == UserRole.SuperAdmin || currentUser.Userrole == UserRole.Admin) && request.Password != null)
            {
                if (request.OldPassword == null) 
                {
                    throw new Exception("Old Password needs to not null"); 
                }

                if(!_hashService.VerifyHash(request.OldPassword, user.PasswordHash))
                {
                    throw new Exception("Old password incorrect");
                }
                user.PasswordHash = _hashService.GetHash(request.Password);
            }

            if(request.Photo != null)
            {
                var photoFileName = await _fileService.SaveFileAsync(request.Photo)
                                                      ?? throw new Exception("Cannot save the photo");

                user.Photo = photoFileName;
            }

            user.Firstname = request.Firstname ?? user.Firstname;
            user.FirstnameRu = request.FirstnameRu ?? user.FirstnameRu;
            user.Lastname = request.Lastname ?? user.Lastname;
            user.LastnameRu = request.LastnameRu ?? user.LastnameRu;
            user.Phone = request.Phone ?? user.Phone;
            user.Email = request.Email ?? user.Email;
            user.Userrole = request.Userrole ?? UserRole.SuperAdmin;
            user.Gender = request.Gender ?? user.Gender;

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}

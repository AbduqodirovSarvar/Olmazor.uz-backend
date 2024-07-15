using MediatR;
using Microsoft.EntityFrameworkCore;
using OlmaTech.Application.Abstractions;
using OlmaTech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.UseCases.AboutToDoList.Commands
{
    public class UpdateAboutCommandHandler(
        IAppDbContext appDbContext,
        IFileService fileService
        ) : IRequestHandler<UpdateAboutCommand, About>
    {
        private readonly IAppDbContext _appDbContext = appDbContext;
        private readonly IFileService _fileService = fileService;

        public async Task<About> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _appDbContext.Abouts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                                           ?? throw new Exception("About not found");

            if(request.Photo != null)
            {
                var newPhotoName = await _fileService.SaveFileAsync(request.Photo);
                about.Photo = newPhotoName ?? about.Photo;
            }

            about.AddressEn = request.AddressEn ?? about.AddressEn;
            about.AddressRu = request.AddressRu ?? about.AddressRu;
            about.AddressUz = request.AddressUz ?? about.AddressUz;
            about.AddressUzRu = request.AddressUzRu ?? about.AddressUzRu;
            about.TitleEn = request.TitleEn ?? about.TitleEn;
            about.TitleRu = request.TitleRu ?? about.TitleRu;
            about.TitleUz = request.TitleUz ?? about.TitleUz;
            about.TitleUzRu = request.TitleUzRu ?? about.TitleUzRu;
            about.DescriptionEn = request.DescriptionEn ?? about.DescriptionEn;
            about.DescriptionRu = request.DescriptionRu ?? about.DescriptionRu;
            about.DescriptionUz = request.DescriptionUz ?? about.DescriptionUz;
            about.DescriptionUzRu = request.DescriptionUzRu ?? about.DescriptionUzRu;
            about.DescriptionFooterEn = request.DescriptionFooterEn ?? about.DescriptionFooterEn;
            about.DescriptionFooterRu = request.DescriptionFooterRu ?? about.DescriptionFooterRu;
            about.DescriptionFooterUz = request.DescriptionFooterUz ?? about.DescriptionFooterUz;
            about.DescriptionFooterUzRu = request.DescriptionFooterUzRu ?? about.DescriptionFooterUzRu;
            about.Experience = request.Experience ?? about.Experience;

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return about;
        }
    }
}

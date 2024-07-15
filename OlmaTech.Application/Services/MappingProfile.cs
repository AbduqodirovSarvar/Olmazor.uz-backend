using AutoMapper;
using OlmaTech.Application.Models;
using OlmaTech.Application.UseCases.AboutToDoList.Commands;
using OlmaTech.Application.UseCases.BlogPostToDoList.Commands;
using OlmaTech.Application.UseCases.ClientToDoList.Commands;
using OlmaTech.Application.UseCases.HomePostToDoList.Commands;
using OlmaTech.Domain.Entities;
using OlmaTech.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlmaTech.Application.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            /*CreateMap<Enum, EnumViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Convert.ToInt32(src)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom<EnumNameResolver<Enum>>());*/

            // Enum -> EnumViewModel
            CreateMap<Enum, EnumViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Convert.ToInt32(src)))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(z => z.ToString()));

            // About -> AboutViewModel
            CreateMap<About, AboutViewModel>()
                // Address
                .ForMember(x => x.Address.En, y => y.MapFrom(z => z.AddressEn))
                .ForMember(x => x.Address.Uz, y => y.MapFrom(z => z.AddressUz))
                .ForMember(x => x.Address.Ru, y => y.MapFrom(z => z.AddressRu))
                .ForMember(x => x.Address.Uzru, y => y.MapFrom(z => z.AddressUzRu))
                // Title
                .ForMember(x => x.Title.En, y => y.MapFrom(z => z.TitleEn))
                .ForMember(x => x.Title.Uz, y => y.MapFrom(z => z.TitleUz))
                .ForMember(x => x.Title.Ru, y => y.MapFrom(z => z.TitleRu))
                .ForMember(x => x.Title.Uzru, y => y.MapFrom(z => z.TitleUzRu))
                // Description
                .ForMember(x => x.Description.En, y => y.MapFrom(z => z.DescriptionEn))
                .ForMember(x => x.Description.Uz, y => y.MapFrom(z => z.DescriptionUz))
                .ForMember(x => x.Description.Ru, y => y.MapFrom(z => z.DescriptionRu))
                .ForMember(x => x.Description.Uzru, y => y.MapFrom(z => z.DescriptionUzRu))
                // Description footer
                .ForMember(x => x.DescriptionFooter.En, y => y.MapFrom(z => z.DescriptionFooterEn))
                .ForMember(x => x.DescriptionFooter.Uz, y => y.MapFrom(z => z.DescriptionFooterUz))
                .ForMember(x => x.DescriptionFooter.Ru, y => y.MapFrom(z => z.DescriptionFooterRu))
                .ForMember(x => x.DescriptionFooter.Uzru, y => y.MapFrom(z => z.DescriptionFooterUzRu));

            // BlogPost -> BlogPostViewModel
            CreateMap<BlogPost, BlogPostViewModel>()
                // Title
                .ForMember(x => x.Title.En, y => y.MapFrom(z => z.TitleEn))
                .ForMember(x => x.Title.Uz, y => y.MapFrom(z => z.TitleUz))
                .ForMember(x => x.Title.Ru, y => y.MapFrom(z => z.TitleRu))
                .ForMember(x => x.Title.Uzru, y => y.MapFrom(z => z.TitleUzRu))
                // Description
                .ForMember(x => x.Description.En, y => y.MapFrom(z => z.DescriptionEn))
                .ForMember(x => x.Description.Uz, y => y.MapFrom(z => z.DescriptionUz))
                .ForMember(x => x.Description.Ru, y => y.MapFrom(z => z.DescriptionRu))
                .ForMember(x => x.Description.Uzru, y => y.MapFrom(z => z.DescriptionUzRu));

            // Client -> ClientViewModel
            CreateMap<Client, ClientViewModel>()
                // Position
                .ForMember(x => x.Position.En, y => y.MapFrom(z => z.PositionEn))
                .ForMember(x => x.Position.Uz, y => y.MapFrom(z => z.PositionUz))
                .ForMember(x => x.Position.Ru, y => y.MapFrom(z => z.PositionRu))
                .ForMember(x => x.Position.Uzru, y => y.MapFrom(z => z.PositionUzRu))
                // Description
                .ForMember(x => x.Comment.En, y => y.MapFrom(z => z.CommentEn))
                .ForMember(x => x.Comment.Uz, y => y.MapFrom(z => z.CommentUz))
                .ForMember(x => x.Comment.Ru, y => y.MapFrom(z => z.CommentRu))
                .ForMember(x => x.Comment.Uzru, y => y.MapFrom(z => z.CommentUzRu));

            // HomePost -> HomePostViewModel
            CreateMap<HomePost, HomePostViewModel>()
                // Subtitle
                .ForMember(x => x.Subtitle.En, y => y.MapFrom(z => z.SubitleEn))
                .ForMember(x => x.Subtitle.Uz, y => y.MapFrom(z => z.SubtitleUz))
                .ForMember(x => x.Subtitle.Ru, y => y.MapFrom(z => z.SubtitleRu))
                .ForMember(x => x.Subtitle.Uzru, y => y.MapFrom(z => z.SubtitleUzRu))
                // Title
                .ForMember(x => x.Title.En, y => y.MapFrom(z => z.TitleEn))
                .ForMember(x => x.Title.Uz, y => y.MapFrom(z => z.TitleUz))
                .ForMember(x => x.Title.Ru, y => y.MapFrom(z => z.TitleRu))
                .ForMember(x => x.Title.Uzru, y => y.MapFrom(z => z.TitleUzRu))
                // Description
                .ForMember(x => x.Description.En, y => y.MapFrom(z => z.DescriptionEn))
                .ForMember(x => x.Description.Uz, y => y.MapFrom(z => z.DescriptionUz))
                .ForMember(x => x.Description.Ru, y => y.MapFrom(z => z.DescriptionRu))
                .ForMember(x => x.Description.Uzru, y => y.MapFrom(z => z.DescriptionUzRu));

            // Project -> ProjectViewModel
            CreateMap<Project, ProjectViewModel>()
                // Name
                .ForMember(x => x.Name.En, y => y.MapFrom(z => z.NameEn))
                .ForMember(x => x.Name.Uz, y => y.MapFrom(z => z.NameUz))
                .ForMember(x => x.Name.Ru, y => y.MapFrom(z => z.NameRu))
                .ForMember(x => x.Name.Uzru, y => y.MapFrom(z => z.NameUzRu))
                // Description
                .ForMember(x => x.Description.En, y => y.MapFrom(z => z.DescriptionEn))
                .ForMember(x => x.Description.Uz, y => y.MapFrom(z => z.DescriptionUz))
                .ForMember(x => x.Description.Ru, y => y.MapFrom(z => z.DescriptionRu))
                .ForMember(x => x.Description.Uzru, y => y.MapFrom(z => z.DescriptionUzRu));

            // Service -> ServiceViewModel
            CreateMap<Service, ServiceViewModel>()
                // Name
                .ForMember(x => x.Name.En, y => y.MapFrom(z => z.NameEn))
                .ForMember(x => x.Name.Uz, y => y.MapFrom(z => z.NameUz))
                .ForMember(x => x.Name.Ru, y => y.MapFrom(z => z.NameRu))
                .ForMember(x => x.Name.Uzru, y => y.MapFrom(z => z.NameUzRu))
                // Description
                .ForMember(x => x.Description.En, y => y.MapFrom(z => z.DescriptionEn))
                .ForMember(x => x.Description.Uz, y => y.MapFrom(z => z.DescriptionUz))
                .ForMember(x => x.Description.Ru, y => y.MapFrom(z => z.DescriptionRu))
                .ForMember(x => x.Description.Uzru, y => y.MapFrom(z => z.DescriptionUzRu));

            // Team -> TeamViewModel
            CreateMap<Team, TeamViewModel>()
                // Position
                .ForMember(x => x.Position.En, y => y.MapFrom(z => z.PositionEn))
                .ForMember(x => x.Position.Uz, y => y.MapFrom(z => z.PositionUz))
                .ForMember(x => x.Position.Ru, y => y.MapFrom(z => z.PositionRu))
                .ForMember(x => x.Position.Uzru, y => y.MapFrom(z => z.PositionUzRu));

            // User -> UserViewModel
            CreateMap<User, UserViewModel>()
                // FirstName
                .ForMember(x => x.Firstname.En, y => y.MapFrom(z => z.Firstname))
                .ForMember(x => x.Firstname.Uz, y => y.MapFrom(z => z.Firstname))
                .ForMember(x => x.Firstname.Ru, y => y.MapFrom(z => z.FirstnameRu))
                .ForMember(x => x.Firstname.Uzru, y => y.MapFrom(z => z.FirstnameRu))
                // LastName
                .ForMember(x => x.Lastname.En, y => y.MapFrom(z => z.Lastname))
                .ForMember(x => x.Lastname.Uz, y => y.MapFrom(z => z.Lastname))
                .ForMember(x => x.Lastname.Ru, y => y.MapFrom(z => z.LastnameRu))
                .ForMember(x => x.Lastname.Uzru, y => y.MapFrom(z => z.LastnameRu));

            // CreateAboutCommand -> About
            CreateMap<CreateAboutCommand, About>()
                .ForMember(x => x.Photo, y => y.Ignore());

            // CreateBlogPostCommand -> BlogPost
            CreateMap<CreateBlogPostCommand, BlogPost>()
                .ForMember(x => x.Photo, y => y.Ignore());

            // CreateClientCommand -> Client
            CreateMap<CreateClientCommand, Client>()
                .ForMember(x => x.Photo, y => y.Ignore());

            // CreateClientCommand -> Client
            CreateMap<CreateClientCommand, Client>().ReverseMap();

            // CreateHomePostCommand -> HomePost
            CreateMap<CreateHomePostCommand, HomePost>()
                .ForMember(x => x.Photo, y => y.Ignore());
        }
    }
}

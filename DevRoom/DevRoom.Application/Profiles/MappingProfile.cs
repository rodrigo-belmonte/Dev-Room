using AutoMapper;
using DevRoom.Application.Features.Contents.Commands.Create;
using DevRoom.Application.Features.Contents.Commands.Publish;
using DevRoom.Application.Features.Contents.Commands.Update;
using DevRoom.Application.Features.Contents.Queries.GetById;
using DevRoom.Application.Features.Contents.Queries.GetContentsList;
using DevRoom.Application.Features.Tags.Commands.Create;
using DevRoom.Application.Features.Tags.Commands.Update;
using DevRoom.Application.Features.Tags.Queries.GetById;
using DevRoom.Application.Features.Tags.Queries.GetList;
using DevRoom.Application.Features.Users.Commands.Login;
using DevRoom.Domain.Entities;

namespace DevRoom.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tag, TagListVm>().ReverseMap();
            CreateMap<Tag, TagDetailVm>().ReverseMap();
            CreateMap<Tag, CreateTagCommand>().ReverseMap();
            CreateMap<Tag, CreateTagDto>().ReverseMap();
            CreateMap<Tag, UpdateTagCommand>().ReverseMap();

            CreateMap<Content, ContentListVm>().ReverseMap();
            CreateMap<Content, ContentDetailVm>().ReverseMap();
            CreateMap<Content, CreateContentCommand>().ReverseMap();
            CreateMap<Content, UpdateContentCommand>().ReverseMap();
            CreateMap<Content, PublishContentCommand>().ReverseMap();

            CreateMap<User, LoginDto>().ReverseMap();

        }

    }
}

using AutoMapper;
using enet_be.Dtos;
using enet_be.Models;

namespace enet_be.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Create Map for PostForUpdateDto and Post
            CreateMap<PostForUpdateDto, Post>();

            CreateMap<UserForUpdateDto, User>();

            CreateMap<CommentForUpdateDto, Comment>();

            CreateMap<PostForReturnDto, Post>();

            CreateMap<AvailableOptionsForReturnDto, AvailableOptions>();

            CreateMap<CommentForReturnDto, Comment>();
        }
    }
}

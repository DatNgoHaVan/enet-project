using AutoMapper;
using enson_be.Dtos;
using enson_be.Models;

namespace enson_be.Helpers
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

            CreateMap<UserForReturnDto,User>();

            CreateMap<UserForSubReturnDto,User>();
        }
    }
}

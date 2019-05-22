using enet_be.Dtos;
using enet_be.Models;

namespace enet_be.Helpers
{
    public static class PostManualMapperProfiles
    {
        public static Post MapFromPostUpdateToPost(this PostForUpdateDto postForUpdate)
        {
            if (postForUpdate != null)
            {
                return new Post
                {
                    Type = postForUpdate.Type,
                    Url = postForUpdate.Url,
                    Content = postForUpdate.Content,
                    Status = postForUpdate.Status,
                    AvailableOptionsId = postForUpdate.AvailableOptionsId,
                };
            }
            return null;
        }

        public static Post MapFromPostForUpdate(this PostForReturnDto postForReturn)
        {
            if (postForReturn != null)
            {
                return new Post
                {
                    PostId = postForReturn.PostId,
                    Type = postForReturn.Type,
                    Url = postForReturn.Url,
                    Content = postForReturn.Content,
                    Status = postForReturn.Status,
                    AvailableOptionsId = postForReturn.AvailableOptions.AvailableOptionsId,
                    AvailableOptions = postForReturn.AvailableOptions,
                    //User = postForReturn.User,
                };
            }
            return null;
        }
    }
}

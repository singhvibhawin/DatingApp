using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId, int targetUSerId);
        Task<AppUsers> GetUserWithLikes(int UserId);
        Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams);

    }
}
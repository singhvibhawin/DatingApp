using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public class IUserRepository
    {
        void Update(AppUsers user);

        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUsers>> GetUsersAsync();
        Task<AppUsers> GetUserByIdAsync(int id);
        Task<AppUsers> GetUserByUsernameAsync(string username);
        Task<IEnumerable<MemberDto>> GetMembersAsync(int id);
        Task<MemberDto> GetMemberAsync(string username);

        internal async Task GetMembersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
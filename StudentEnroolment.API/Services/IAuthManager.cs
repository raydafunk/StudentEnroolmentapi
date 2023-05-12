using Microsoft.AspNetCore.Identity;
using StudentEnroolment.API.Dtos.Authentication;

namespace StudentEnroolment.API.Services
{
    public interface IAuthManager
    {
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<IEnumerable<IdentityError>>Register(RegisterDto registorDto);
    }
}

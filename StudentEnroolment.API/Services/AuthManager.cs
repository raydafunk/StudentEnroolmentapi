using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StudentEnrollment.data;
using StudentEnroolment.API.Dtos.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentEnroolment.API.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<SchoolUser> _userManager;
        private readonly IConfiguration _configuration;
        private SchoolUser? _user;

        public AuthManager(UserManager<SchoolUser> userManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._configuration = configuration;
        }
    
        public  async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            _user = await _userManager.FindByEmailAsync(loginDto.EmailAddress!);
            if (_user is null)
            {
                return default!;
            }
            bool isVaildCredentails = await _userManager.CheckPasswordAsync(_user, loginDto.Password!);
            if (!isVaildCredentails)
            {
                return default!;
            }

            // Generated Token Here
            var Token = await GenerateTokenAsync();
            return new AuthResponseDto
            {
                Token = Token,
                UserId = _user.Id,
            };
        }

        public async Task<IEnumerable<IdentityError>> Register(RegisterDto registorDto)
        {
            _user = new SchoolUser
            {
                DateOfBrith = registorDto.DateOfBirth,
                Email = registorDto.EmailAddress,
                UserName = registorDto.EmailAddress,
                FristName = registorDto.FirstName!,
                LastName = registorDto.LastName!
            };

            var result = await _userManager.CreateAsync(_user, registorDto.Password!);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(_user, "User");
            }
            return result.Errors;
        }

        private async Task<string> GenerateTokenAsync()
        {
            var serectkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(serectkey, SecurityAlgorithms.HmacSha256);
            
            var roles = await _userManager.GetRolesAsync(_user!);
            var rolesClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(_user!);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user!.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user!.Email!),
                new Claim("userId", _user!.Id),
            }.Union(userClaims).Union(rolesClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToInt32(_configuration["JwtSettings:DurationInHours"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

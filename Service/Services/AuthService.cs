using Microsoft.EntityFrameworkCore;
using RecipeBook.Domain.Dtos;
using RecipeBook.Domain.Entities;
using RecipeBook.Domain.Interfaces;

namespace RecipeBook.Business.Services
{
    public class AuthService
    {
        private readonly TokenService _tokenService;
        private readonly IRepository<User> _userRepository;

        public AuthService(TokenService tokenService, IRepository<User> userRepository)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto loginRequestDto)
        {
            User DbUser = await _userRepository.GetAll().FirstOrDefaultAsync(u => u.Email == loginRequestDto.Email);
            if (DbUser is null)
                return ApiResponse<AuthResponseDto>.Fail("User does not exist");
            if (DbUser.Password != loginRequestDto.Password)
                return ApiResponse<AuthResponseDto>.Fail("Incorrect Password");

            var token = _tokenService.GenerateJwt(DbUser);
            return ApiResponse<AuthResponseDto>.Success(new AuthResponseDto(DbUser.Id, DbUser.Name, token));
        }
    }
}
using AutoMapper;
using BusinessLogicLayer.Exceptions;
using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Data.Repositories;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(UserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException($"User with ID {userId} not found");
        }
        return _mapper.Map<UserDto>(user);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default)
    {
        var users = await _userRepository.GetAllUsersAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> CreateUserAsync(UserDto user,CancellationToken cancellationToken = default)
    {
        User userModel = _mapper.Map<User>(user);
        userModel.CreatedDate = DateTime.Now;

        await _userRepository.AddAsync(userModel, cancellationToken);
        return user;
    }
      
    public async Task UpdateUserAsync(int userId, UserDto updatedUser, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException($"User with ID {userId} not found");
        }

        _mapper.Map(updatedUser, user);
        user.UpdatedDate = DateTime.UtcNow;

        await _userRepository.UpdateAsync(user, cancellationToken);
    }

    public async Task DeleteUserAsync(int userId, CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user == null)
        {
            throw new NotFoundException($"User with ID {userId} not found");
        }

        await _userRepository.DeleteAsync(user.Id, cancellationToken);
    }
}

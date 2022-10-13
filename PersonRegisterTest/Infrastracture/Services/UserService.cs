using AutoMapper;
using PersonRegisterTest.Infrastracture.DTOs;
using PersonRegisterTest.Infrastracture.Entities;
using PersonRegisterTest.Infrastracture.Repository;

namespace PersonRegisterTest.Infrastracture.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;
        public UserService(IUserRepo repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<User> CreateUserAsync(UserDTO model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            return await _repo.CreateUser(_mapper.Map<User>(model));
        }

        public async Task DeleteUserAsync(int id)
        {
            var userForDelete = await _repo.GetSignleUser(id);
            if(userForDelete!=null)
            {
                await _repo.DeleteUser(userForDelete);
            }
            else
            {
                throw new ArgumentNullException(nameof(userForDelete));
            }
            
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _repo.GetSignleUser(id);
            if(user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> GetUsersListAsync()
        {
            var userList = await _repo.GetUsers();
            return  _mapper.Map<List<UserDTO>>(userList);
        }

        public async Task<User> UpdateUserAsync(int id,UserDTO model)
        {
            if(id!=model.Id)
            {
                throw new Exception();
            }
           return await _repo.UpdateUser(_mapper.Map<User>(model));
        }
    }
}

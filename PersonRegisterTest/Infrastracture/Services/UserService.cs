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

        /// <summary>
        /// Register A User To DB
        /// </summary>
        /// <param name="model"></param>
        /// <returns>User</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<User> CreateUserAsync(UserDTO model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            return await _repo.CreateUser(_mapper.Map<User>(model));
        }

        /// <summary>
        /// Soft Delete A User with Is Active
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Retrive a User with Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _repo.GetSignleUser(id);
            if(user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            return _mapper.Map<UserDTO>(user);
        }

        /// <summary>
        /// Get List of Users
        /// </summary>
        /// <returns>List<UserDTO></returns>
        public async Task<List<UserDTO>> GetUsersListAsync()
        {
            var userList = await _repo.GetUsers();
            return  _mapper.Map<List<UserDTO>>(userList);
        }

        /// <summary>
        /// Update a user in db
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

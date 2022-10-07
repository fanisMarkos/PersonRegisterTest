using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonRegisterTest.Infrastracture.DTOs;
using PersonRegisterTest.Infrastracture.Entities;
using PersonRegisterTest.Infrastracture.Repository;

namespace PersonRegisterTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;

        public UserController(IUserRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
   

        
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetList()
        {
            var resultList = await _repo.GetUsers();
            if(resultList!=null)
            {
                var userList = _mapper.Map<List<UserDTO>>(resultList);
                return Ok(userList);
            }
            else
            {
                return BadRequest();
            }
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _repo.GetSignleUser(id);
            if(user!=null)
            {
                return Ok(_mapper.Map<UserDTO>(user));
            }
            else
            {
                return NotFound();
            }
        }

        
        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] UserDTO model)
        {
            if(ModelState.IsValid)
            {
                var user = _mapper.Map<User>(model);
                await _repo.CreateUser(user);
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserDTO model)
        {
            if(ModelState.IsValid)
            {

                var userModel = _mapper.Map<User>(model);
                await _repo.UpdateUser(userModel);
                return Ok(userModel);
            }
            return BadRequest();
        }

        
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repo.DeleteUser(id);
            return Ok();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonRegisterTest.Infrastracture.DTOs;
using PersonRegisterTest.Infrastracture.Entities;
using PersonRegisterTest.Infrastracture.Repository;
using PersonRegisterTest.Infrastracture.Services;

namespace PersonRegisterTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetList()
        {
            try
            {
                var resultList = await _userService.GetUsersListAsync();
                return Ok(resultList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserCreateEditDto>> GetUser(int id)
        {
            try
            {
                var userResult = await _userService.GetUserByIdAsync(id);
                return Ok(userResult);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }


        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] UserCreateEditDto model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _userService.CreateUserAsync(model);
                    return Ok();
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }


        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserCreateEditDto model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _userService.UpdateUserAsync(id,model);
                    return Ok();
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }


        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("UserTitles")]
        public async Task<ActionResult<List<UserTitle>>> GetUserTitles()
        {
            try
            {
                var userTitles = await _userService.GetUserTittlesSync();
                return Ok(userTitles);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("UserTypes")]
        public async Task<ActionResult<List<UserType>>> GetUserTypes()
        {
            try
            {
                var userTypes = await _userService.GetUserTypesAsync();
                return Ok(userTypes);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}

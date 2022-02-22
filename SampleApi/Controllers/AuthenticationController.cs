using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SampleApi.Mapper;
using SampleApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUsersRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public AuthenticationController(IConfiguration config, IUsersRepository userRepository, IMapper mapper)
        {
            _config=config;
            _userRepository=userRepository;
            _mapper=mapper;
        }
        [HttpPost("Register")]
        public ActionResult Register([FromBody] UsersDTO user)
        {
            if (user==null || user.Email==null)
            {
                return BadRequest("400");
            }

            if (!_userRepository.GetRegister(user))
            {
                ModelState.AddModelError("", "Something went wrong ");
                return StatusCode(404, ModelState);
            }

            return Ok("User Created");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO request)
        {

            if (request==null)
            {
                return BadRequest();
            }
            if (request.Password==null)

            {
                return BadRequest();
            }
            if (string.IsNullOrEmpty(request.Email))
            {
                return BadRequest();
            }

            var obj =  await _userRepository.Login(request);


            return Ok(obj);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var obj= _userRepository.GetUsers();
            var objDto = new List<UsersDTO>();
            foreach (var item in obj)
            {
                objDto.Add(_mapper.Map<UsersDTO>(item));


            }
            return Ok(objDto);
        }
    }
}

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Dtos;
using Api.Errors;
using Api.Extensions;
using AutoMapper;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signManager;
        private readonly IMapper _mapper;
        public AccountController(UserManager<Customer> userManager,
                                SignInManager<Customer> signManager,
                                ITokenService tokenService,
                                IMapper mapper)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _signManager = signManager;
            _userManager = userManager;
        }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<CustomerDto>> GetCurrentUser()
    {

        var customer = await _userManager.FindByEmailFromClaimsPrincipals(HttpContext.User);

        return new CustomerDto
        {
            Name = customer.Name,
            Email = customer.Email,
            Token = _tokenService.CreateToken(customer)
        };
    }



    
    [HttpGet("emailexist")]
    public async Task<ActionResult<bool>> CheckEmailExistAsync([FromQuery] string email)
    {
        return await _userManager.FindByEmailAsync(email) != null;
    }

    [HttpPost("login")]
    public async Task<ActionResult<CustomerDto>> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null) return Unauthorized(new ApiResponse(401));

        var result = await _signManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

        return new CustomerDto
        {
            Name = user.Name,
            Email = user.Email,
            Token = _tokenService.CreateToken(user)
        };
    }
    [HttpPost("register")]
    public async Task<ActionResult<CustomerDto>> Register(RegisterDto registerDto)
    {
        if (CheckEmailExistAsync(registerDto.Email).Result.Value)
        {
            return new BadRequestObjectResult(new ApiValidationErrorResponse{
                Errors = new []{"Sorry , Email Address is in use."}
            });
        }
        
        var user = new Customer
        {
            Name = registerDto.Name,
            UserName = registerDto.Email,
            Email = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded) return BadRequest(new ApiResponse(400));

        return new CustomerDto
        {
            Name = user.Name,
            Email = user.Email,
            Token = _tokenService.CreateToken(user)
        };
    }
}
}

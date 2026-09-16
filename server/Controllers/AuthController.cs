using Microsoft.AspNetCore.Mvc;
using Server.DTOs;
using Server.Services;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IEnhanzerAuthService _enhanzerAuthService;
        private readonly IJwtService _jwtService;

        public AuthController(IEnhanzerAuthService enhanzerAuthService, IJwtService jwtService)
        {
            _enhanzerAuthService = enhanzerAuthService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
{
    if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
    {
        return BadRequest(new LoginResponseDto
        {
            Success = false,
            ErrorMessage = "Email and password are required."
        });
    }

    var enhanzerResponse = await _enhanzerAuthService.LoginAsync(request.Email, request.Password);

    if (enhanzerResponse == null)
    {
        return StatusCode(502, new LoginResponseDto
        {
            Success = false,
            ErrorMessage = "Unable to reach the authentication service. Please try again."
        });
    }

    var userRecord = enhanzerResponse.Response_Body?.FirstOrDefault();

    // The real success signal is a populated User_Locations array — Status_Code stays 200
    // and Response_Body still has an item even on a wrong password.
    var loginSucceeded = enhanzerResponse.Status_Code == 200
        && userRecord != null
        && userRecord.User_Locations != null
        && userRecord.User_Locations.Count > 0;

    if (!loginSucceeded)
    {
        return Unauthorized(new LoginResponseDto
        {
            Success = false,
            ErrorMessage = userRecord?.Doc_Msg ?? enhanzerResponse.Message ?? "Invalid email or password."
        });
    }

    var locations = userRecord!.User_Locations!
        .Select(l => new UserLocationDto
        {
            Location_Code = l.Location_Code,
            Location_Name = l.Location_Name
        })
        .ToList();

    var token = _jwtService.GenerateToken(request.Email);

    return Ok(new LoginResponseDto
    {
        Success = true,
        Token = token,
        Locations = locations
    });
}
    }
}
namespace Server.DTOs
{
    public class LoginRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponseDto
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public string? ErrorMessage { get; set; }
        public List<UserLocationDto> Locations { get; set; } = new();
    }

    public class UserLocationDto
    {
        public string Location_Code { get; set; } = string.Empty;
        public string Location_Name { get; set; } = string.Empty;
    }
}
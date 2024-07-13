namespace API.Dtos
{
    public class AppUserDto
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Code { get; set; } = "";
    }
}

namespace EFaturaTakip.DTO.User
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int Type { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public string Token { get; set; }
        public DateTime Expirytime { get; set; }
    }
}

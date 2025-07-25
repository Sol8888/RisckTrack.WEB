﻿namespace RisckTrack.WEB.Models
{
    public class UserDto
    {
        public int UserId { get; set; }
        public int? CompanyId { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string Role { get; set; } = "U";
    }
}

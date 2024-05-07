﻿namespace ToolPedia.Domain.Entities
{
    public class User
    {
        public required Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public required string PasswordSalt { get; set; }
        //public ICollection<Comment>? Comments { get; set; }
        //public ICollection<ToolRating>? ToolRatings { get; set; }
    }
}

using System;
using DataModel.Models.Users;

namespace DataModel.Models.UserIdentities
{
    public class UserIdentity : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        
        public DateTime? LastUpdatedUtc { get; set; }
    }
}
using System;
using DataModel.Models.UserIdentities;
using DataModel.Models.Users.UserStatusRefs;

namespace DataModel.Models.Users
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }

        public UserStatusRef StatusRef { get; }
        public UserStatusEnum Status { get; set; } = UserStatusEnum.WaitingApproval;

        public DateTime? LastUpdatedUtc { get; set; }
        
        public UserIdentity Identity { get; set; }
    }
}
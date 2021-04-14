namespace DataModel.Models.Users.UserStatusRefs
{
    public class UserStatusRef
    {
        public UserStatusEnum Id { get; set; }
        public string Name { get; set; }

        public UserStatusRef(UserStatusEnum status)
        {
            Id = status;
            Name = status.ToString();
        }
    }
}
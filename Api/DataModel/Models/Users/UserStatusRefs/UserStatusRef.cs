namespace DataModel.Models.Users.UserStatusRefs
{
    public class UserStatusRef
    {
        public UserStatusEnum Id { get; }
        public string Name { get; }

        public UserStatusRef(UserStatusEnum status)
        {
            Id = status;
            Name = status.ToString();
        }
    }
}
namespace DataModel.Models.Users.UserStatusRefs
{
    public class UserStatusRef : BaseModelEnum<UserStatusEnum>
    {
        public UserStatusRef(UserStatusEnum baseModelEnum) : base(baseModelEnum)
        {
        }
    }
}
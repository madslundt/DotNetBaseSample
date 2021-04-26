namespace DataModel.Models.Users.UserStatusRefs
{
    public class UserStatusRef : BaseModelEnum<UserStatusEnum>
    {
        public UserStatusRef()
        {}
        public UserStatusRef(UserStatusEnum baseModelEnum) : base(baseModelEnum)
        {}
    }
}
namespace user_service
{
    public partial class UserUseCase : IUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IItemClient _itemClient;

        public UserUseCase(
            IUserRepository userRepository,
            IItemClient itemClient
            )
        {
            _userRepository = userRepository;
            _itemClient = itemClient;
        }
    }
}


namespace user_service
{
    public partial class UserUseCase : IUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public UserUseCase(
            IUserRepository userRepository
            )
        {
            _userRepository = userRepository;
        }
    }
}

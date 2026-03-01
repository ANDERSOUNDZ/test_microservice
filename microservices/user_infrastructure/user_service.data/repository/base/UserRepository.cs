using user_service.data.context;

namespace user_service
{
    public partial class UserRepository : IUserRepository
    {
        private readonly UserDbContext _context;

        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
    }
}

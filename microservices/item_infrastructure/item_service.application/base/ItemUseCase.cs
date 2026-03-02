
namespace item_service
{
    public partial class ItemUseCase : IItemUseCase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUserClient _userClient;
        public ItemUseCase(
            IItemRepository itemRepository,
            IUserClient userClient
            )
        {
            _itemRepository = itemRepository;
            _userClient = userClient;
        }
    }
}

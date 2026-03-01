
namespace item_service
{
    public partial class ItemUseCase : IItemUseCase
    {
        private readonly IItemRepository _itemRepository;

        public ItemUseCase(
            IItemRepository itemRepository
            )
        {
            _itemRepository = itemRepository;
        }
    }
}

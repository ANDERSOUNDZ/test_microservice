
namespace item_service
{
    /// <summary>
    /// Implementación de la lógica de negocio para ítems.
    /// Parte de la clase encargada de la inyección de dependencias y composición.
    /// </summary>
    public partial class ItemUseCase : IItemUseCase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUserClient _userClient;

        /// <summary>
        /// Constructor principal para la orquestación de casos de uso.
        /// </summary>
        /// <param name="itemRepository">Puerto de acceso a datos de ítems.</param>
        /// <param name="userClient">Puerto de comunicación con el servicio de usuarios.</param>
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

namespace user_service
{
    /// <summary>
    /// Implementación de los casos de uso de usuario.
    /// Esta parte de la clase gestiona la inyección de dependencias necesarias 
    /// para orquestar la lógica entre el dominio y la infraestructura.
    /// </summary>
    public partial class UserUseCase : IUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IItemClient _itemClient;

        /// <summary>
        /// Constructor principal que recibe los puertos de salida (repositorio y clientes externos).
        /// </summary>
        /// <param name="userRepository">Acceso a la persistencia de datos de usuario.</param>
        /// <param name="itemClient">Cliente para validar reglas de negocio en otros microservicios.</param>
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

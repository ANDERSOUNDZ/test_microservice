namespace user_service.domain.entities
{
    public class UsuarioEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string NombreCompleto { get; set; } = string.Empty;
        public bool EstaActivo { get; set; } = true;
    }
}

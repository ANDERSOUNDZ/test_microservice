namespace item_service.domain.entities
{
    public class ItemTrabajoEntity
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool EsAltaRelevancia { get; set; }
        public string Estado { get; set; }
        public string UsuarioAsignado { get; set; }
    }
}

namespace item_service.ports.dto.item
{
    public record ItemPendienteResponse(
        Guid Id,
        string Titulo,
        string FechaEntrega,
        bool EsAltaRelevancia,
        string UsuarioAsignado,
        string Estado
    );
}

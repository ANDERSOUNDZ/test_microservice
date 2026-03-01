namespace item_service.ports.dto.item
{
    public record ItemPendienteResponse(
        Guid Id,
        string Titulo,
        DateTime FechaEntrega,
        bool EsAltaRelevancia,
        string UsuarioAsignado
    );
}

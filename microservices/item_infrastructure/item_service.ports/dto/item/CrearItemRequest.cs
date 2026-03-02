namespace item_service.ports.dto.item
{
    public record CrearItemRequest(
        string Titulo,
        DateTime FechaEntrega,
        bool EsAltaRelevancia
        );
}
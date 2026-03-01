
namespace item_service.ports.dto.item
{
    public class ResumenUsuario
    {
        public string Username { get; set; } = string.Empty;
        public int TotalPendientes { get; set; }
        public int TotalAltaRelevancia { get; set; }
    }
}

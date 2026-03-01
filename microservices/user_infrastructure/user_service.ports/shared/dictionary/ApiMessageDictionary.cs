
namespace user_service.ports.shared.dictionary
{
    public static class ApiMessageDictionary
    {
        private static readonly Dictionary<enums.ApiMessage, string> _messages = new()
        {
            { enums.ApiMessage.BadRequest, "Solicitud incorrecta" },
            { enums.ApiMessage.OperationSuccess, "Operación realizada con éxito" },
            { enums.ApiMessage.ValidationError, "Error de validación" },
            { enums.ApiMessage.InternalServerError, "Error interno del servidor" },
        };
        public static string GetMessage(this enums.ApiMessage message)
        {
            return _messages.TryGetValue(message, out var msg) ? msg : "Mensaje desconocido";
        }
    }
}

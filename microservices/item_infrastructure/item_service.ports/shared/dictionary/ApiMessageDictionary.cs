using item_service.ports.shared.enums;

namespace item_service.ports.shared.dictionary
{
    public static class ApiMessageDictionary
    {
        private static readonly Dictionary<ApiMessage, string> _messages = new()
        {
            { ApiMessage.BadRequest, "Solicitud incorrecta" },
            { ApiMessage.OperationSuccess, "Operación realizada con éxito" },
            { ApiMessage.ValidationError, "Error de validación" },
            { ApiMessage.InternalServerError, "Error interno del servidor" },
            { ApiMessage.TaskSuccessfullyCompleted, "Tarea completada exitosamente" }
        };
        public static string GetMessage(this ApiMessage message)
        {
            return _messages.TryGetValue(message, out var msg) ? msg : "Mensaje desconocido";
        }
    }
}

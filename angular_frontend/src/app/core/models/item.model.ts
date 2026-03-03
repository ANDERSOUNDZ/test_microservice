/**
 * DTO para la creación de un ítem de trabajo.
 */
export interface CrearItemRequest {
  titulo: string;
  fechaEntrega: string; // Formato ISO para compatibilidad con .NET
  esAltaRelevancia: boolean;
}

/**
 * Representa la respuesta de un ítem pendiente de finalización.
 */
export interface ItemPendienteResponse {
  id: string;
  titulo: string;
  fechaEntrega: Date;
  esAltaRelevancia: boolean;
  usuarioAsignado: string;
  estado: string;
}

/**
 * Request para marcar un ítem como completado.
 */
export interface CompletarItemRequest {
  itemId: string;
}
